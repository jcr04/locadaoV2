using locadao.Domain.Models;
using System;
using System.Collections.Generic;

namespace Locadao.Application.Interfaces.Queries;

public class GetClienteByIdQuery
{
    public Guid Id { get; set; }
}

public class GetClienteByCpfQuery
{
    public string Cpf { get; set; }
}