using locadao.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Locadão.Infra.Repository.Alugueis
{
    public interface IAluguelRepository
    {
        Task<Aluguel> AddAsync(Aluguel aluguel);
        Task DeleteAsync(Guid id);
        Task<Aluguel> GetAluguelByIdAsync(Guid id);
    }
}
