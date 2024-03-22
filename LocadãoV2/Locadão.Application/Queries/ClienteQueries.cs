namespace Locadao.Application.Interfaces.Queries;

public class GetClienteByIdQuery
{
    public Guid Id { get; set; }
}

public class GetClienteByCpfQuery
{
    public string Cpf { get; set; }
}