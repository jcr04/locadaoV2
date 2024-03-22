using System;

namespace Locadao.Application.Commands.Agencias;

public class CreateAgenciaCommand
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
}

public class DeleteAgenciaCommand
{
    public Guid Id { get; set; }
}