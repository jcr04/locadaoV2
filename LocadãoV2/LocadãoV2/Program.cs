using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using locadao.Infrastructure;
using Locadao.Application.Interfaces.Commands;
using Locad�o.Infra.Repository.Clientes;
using Locadao.Application.Commands.Veiculos;
using Locad�o.Infra.Repository.Veiculos;
using Locadao.Application.Commands.Agencias;
using Locad�o.Infra.Repository.Agencias;
using Locad�o.Infra.Repository.Alugueis;
using Locad�o.Application.Commands;
using Locad�o.Application.Queries;
using Locad�o.Application.Handlers;
using Locad�o.Infra.Repository.Reservas;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona os servi�os ao container.
        builder.Services.AddControllers();

        // Configura o DbContext
        builder.Services.AddDbContext<LocadaoDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Adiciona os demais servi�os necess�rios
        // builder.Services.AddScoped, .AddTransient, .AddSingleton, etc.
        
        //Cliente
        builder.Services.AddTransient<ICommandHandler<CreateClienteCommand>, CreateClienteCommandHandler>();
        builder.Services.AddTransient<ICommandHandler<UpdateClienteCommand>, UpdateClienteCommandHandler>();
        builder.Services.AddTransient<ICommandHandlerDelete<DeleteClienteCommand>, DeleteClienteCommandHandler>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IClienteQueryService, ClienteQueryService>();
        
        //Veiculo
        builder.Services.AddTransient<ICommandHandler<CreateVeiculoCommand>, CreateVeiculoCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<UpdateVeiculoCommand>, UpdateVeiculoCommandHandler>();
        builder.Services.AddScoped<ICommandHandlerDelete<DeleteVeiculoCommand>, DeleteVeiculoCommandHandler>();
        builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        builder.Services.AddScoped<IVeiculoQueryService, VeiculoQueryService>();

        //Agencia
        builder.Services.AddTransient<ICommandHandler<CreateAgenciaCommand>, CreateAgenciaCommandHandler>();
        builder.Services.AddTransient<ICommandHandlerDelete<DeleteAgenciaCommand>, DeleteAgenciaCommandHandler>();
        builder.Services.AddScoped<IAgenciaRepository, AgenciaRepository>();
        builder.Services.AddScoped<IAgenciaQueryService, AgenciaQueryService>();

        //aluguel
        builder.Services.AddTransient<ICommandHandler<CreateAluguelCommand>, CreateAluguelCommandHandler>();
        builder.Services.AddTransient<ICommandHandlerDelete<DeleteAluguelCommand>, DeleteAluguelCommandHandler>();
        builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();
        builder.Services.AddScoped<IAluguelQueryService, AluguelQueryService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Reserva
        builder.Services.AddTransient<ICommandHandler<CreateReservaCommand>, CreateReservaCommandHandler>();
        builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
        builder.Services.AddScoped<IReservaQueryService, ReservaQueryService>();


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