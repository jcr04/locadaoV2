using Locadão.Application.Commands;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Alugueis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Handlers
{
    public class DeleteAluguelCommandHandler : ICommandHandlerDelete<DeleteAluguelCommand>
    {
        private readonly IAluguelRepository _aluguelRepository;

        public DeleteAluguelCommandHandler(IAluguelRepository aluguelRepository)
        {
            _aluguelRepository = aluguelRepository;
        }

        public async Task HandleAsync(DeleteAluguelCommand command)
        {
            await _aluguelRepository.DeleteAsync(command.Id);
        }
    }
}
