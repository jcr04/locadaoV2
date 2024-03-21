using locadao.Domain.Models;

namespace Locadao.Application.Interfaces.Queries
{
    public interface IClienteQueryService
    {
        Task<Cliente> GetClienteByIdAsync(Guid id);
    }
}
