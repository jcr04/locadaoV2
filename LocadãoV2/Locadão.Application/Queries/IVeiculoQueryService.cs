using locadao.Domain.Models;
using Locadão.Domain.models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Queries
{
    public interface IVeiculoQueryService
    {
        Task<VeiculoDTO> GetVeiculoByIdAsync(Guid id);
        Task<IEnumerable<VeiculoDTO>> GetVeiculosDisponiveisAsync();
    }
}
