using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Queries
{
    public interface IAluguelQueryService
    {
        Task<Aluguel> GetAluguelByIdAsync(Guid id);
    }
}
