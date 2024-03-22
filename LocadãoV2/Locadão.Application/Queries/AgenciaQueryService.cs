using locadao.Domain.Models;
using Locadão.Infra.Repository.Agencias;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadão.Application.Queries
{
    public class AgenciaQueryService : IAgenciaQueryService
    {
        private readonly IAgenciaRepository _agenciaRepository;

        public AgenciaQueryService(IAgenciaRepository agenciaRepository)
        {
            _agenciaRepository = agenciaRepository;
        }

        public async Task<Agencia> GetAgenciaByIdAsync(Guid id)
        {
            return await _agenciaRepository.GetAgenciaByIdAsync(id);
        }
    }
}
