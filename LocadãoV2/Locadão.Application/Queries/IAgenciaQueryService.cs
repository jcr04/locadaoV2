using locadao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadão.Application.Queries
{
    public interface IAgenciaQueryService
    {
        Task<AgenciaDTO> GetAgenciaByIdAsync(Guid id);

        Task<List<AgenciaDTO>> GetAllAgenciasAsync();
        Task<int> CountVeiculosByAgenciaAsync(Guid agenciaId);
        Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId);
    }
}
