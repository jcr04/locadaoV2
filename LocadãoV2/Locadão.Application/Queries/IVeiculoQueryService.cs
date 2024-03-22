using locadao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Queries
{
    public interface IVeiculoQueryService
    {
        Task<Veiculo> GetVeiculoByIdAsync(Guid id);
    }
}
