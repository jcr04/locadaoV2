using locadao.Domain.Models;
using Locadão.Domain.models.DTOs;

namespace Locadao.Application.Interfaces.Queries
{
    public interface IClienteQueryService
    {
        Task<ClienteDTO> GetClienteByIdAsync(Guid id);
    }
}
