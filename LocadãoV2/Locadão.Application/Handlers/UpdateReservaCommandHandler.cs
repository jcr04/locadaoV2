using Locadão.Application.Commands;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Reservas;
using Locadão.Infra.Repository.Veiculos;


namespace Locadão.Application.Handlers
{
    public class UpdateReservaCommandHandler : ICommandHandler<UpdateReservaCommand>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public UpdateReservaCommandHandler(IReservaRepository reservaRepository, IVeiculoRepository veiculoRepository)
        {
            _reservaRepository = reservaRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Guid> HandleAsync(UpdateReservaCommand command)
        {
            var reserva = await _reservaRepository.GetByIdAsync(command.ReservaId);
            if (reserva == null)
            {
                throw new Exception("Reserva não encontrada.");
            }

            // Atualizações do veículo e/ou datas conforme a lógica de negócios.
            if (command.NovoVeiculoId.HasValue)
            {
                var veiculoDisponivel = await _veiculoRepository.VerificarDisponibilidadeAsync(command.NovoVeiculoId.Value, command.NovaDataInicio ?? reserva.DataInicio, command.NovaDataFim ?? reserva.DataFim);
                if (!veiculoDisponivel)
                {
                    throw new Exception("Veículo não disponível para o período selecionado.");
                }

                reserva.VeiculoId = command.NovoVeiculoId.Value;
            }

            if (command.NovaDataInicio.HasValue && command.NovaDataFim.HasValue)
            {
                reserva.DataInicio = command.NovaDataInicio.Value;
                reserva.DataFim = command.NovaDataFim.Value;
            }

            await _reservaRepository.UpdateReservaAsync(reserva);

            return reserva.Id;
        }
    }
}
