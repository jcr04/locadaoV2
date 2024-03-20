using locadao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadão.Infra.Repository.Clientes
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Guid id);
    }
}
