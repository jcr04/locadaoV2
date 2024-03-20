using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using locadao.Infrastructure;
using Locadão.Application.Handlers;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Clientes;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona os serviços ao container.
        builder.Services.AddControllers();

        // Configura o DbContext
        builder.Services.AddDbContext<LocadaoDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Adiciona os demais serviços necessários
        // builder.Services.AddScoped, .AddTransient, .AddSingleton, etc.
        builder.Services.AddTransient<ICommandHandler<CreateClienteCommand>, CreateClienteCommandHandler>();
        builder.Services.AddTransient<ICommandHandler<UpdateClienteCommand>, UpdateClienteCommandHandler>();
        builder.Services.AddTransient<ICommandHandler<DeleteClienteCommand>, DeleteClienteCommandHandler>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        // Adiciona suporte a HTTPS
        builder.Services.AddHttpsRedirection(options =>
        {
            options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            options.HttpsPort = 5001;
        });


        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}