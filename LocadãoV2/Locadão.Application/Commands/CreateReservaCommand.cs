using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Commands
{
    public class CreateReservaCommand
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
