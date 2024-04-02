using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Commands
{
    public class UpdateReservaCommand
    {
        public Guid ReservaId { get; set; }
        public Guid? NovoVeiculoId { get; set; }
        public DateTime? NovaDataInicio { get; set; }
        public DateTime? NovaDataFim { get; set; }
    }
}
