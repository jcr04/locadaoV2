using Locadão.Domain.models.DTOs.Locadão.Domain.models.DTOs;
using Locadão.Infra.Repository.Reservas;


namespace Locadão.Application.Queries
{
    public class ReservaQueryService : IReservaQueryService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaQueryService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<ReservaDTO> GetReservaByIdAsync(Guid id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null) return null;

            return new ReservaDTO
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                ClienteNome = reserva.Cliente.Nome, // Supondo que a entidade Cliente esteja carregada
                VeiculoId = reserva.VeiculoId,
                VeiculoDescricao = $"{reserva.Veiculo.Marca} {reserva.Veiculo.Modelo}", // Supondo que a entidade Veiculo esteja carregada
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                Status = reserva.Status
            };
        }

        public async Task<IEnumerable<ReservaDTO>> GetReservasByClienteIdAsync(Guid clienteId)
        {
            var reservas = await _reservaRepository.GetByClienteIdAsync(clienteId);
            return reservas.Select(reserva => new ReservaDTO
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                ClienteNome = reserva.Cliente.Nome, // Supondo que a entidade Cliente esteja carregada
                VeiculoId = reserva.VeiculoId,
                VeiculoDescricao = $"{reserva.Veiculo.Marca} {reserva.Veiculo.Modelo}", // Supondo que a entidade Veiculo esteja carregada
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                Status = reserva.Status
            }).ToList();
        }

        // Implementar outros métodos conforme necessário
    }
}
