using locadao.Domain.Models;
using Locadão.Domain.models.DTOs;

namespace Locadão.Application.Queries
{
    public interface IClienteQueryService
    {
        Task<ClienteDTO> GetClienteByIdAsync(Guid id);
        Task<IEnumerable<ClienteDTO>> GetClientesDisponiveisAsync();
    }
}
