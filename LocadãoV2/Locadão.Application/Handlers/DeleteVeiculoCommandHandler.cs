using Locadao.Application.Commands.Veiculos;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Handlers
{
    public class DeleteVeiculoCommandHandler : ICommandHandlerDelete<DeleteVeiculoCommand>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public DeleteVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task HandleAsync(DeleteVeiculoCommand command)
        {
            await _veiculoRepository.DeleteAsync(command.Id);
        }
    }
}
