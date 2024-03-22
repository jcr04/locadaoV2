using locadao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadão.Application.Queries
{
    public interface IAgenciaQueryService
    {
        Task<Agencia> GetAgenciaByIdAsync(Guid id);
    }
}
