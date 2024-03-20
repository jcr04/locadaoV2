using locadao.Domain.Models;
using System;

namespace Locadao.Application.Interfaces.Commands;

public class CreateClienteCommand
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public bool TemCNH { get; set; }
    public bool IsPCD { get; set; }
}

public class UpdateClienteCommand
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public int Idade { get; set; }
    
    public string Email { get; set; }

    public string Telefone { get; set;}
}



public class DeleteClienteCommand
{
    public Guid Id { get; set; }
}
