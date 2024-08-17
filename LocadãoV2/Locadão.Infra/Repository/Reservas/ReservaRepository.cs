using locadao.Infrastructure;
using Microsoft.EntityFrameworkCore;

using Locadão.Domain.models;

namespace Locadão.Infra.Repository.Reservas
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly LocadaoDbContext _context;

        public ReservaRepository(LocadaoDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> AddAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<Reserva> GetByIdAsync(Guid id)
        {
            return await _context.Reservas
                                 .Include(r => r.Cliente)
                                 .Include(r => r.Veiculo)
                                 .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reserva>> GetByClienteIdAsync(Guid clienteId)
        {
            return await _context.Reservas
                                 .Where(r => r.ClienteId == clienteId)
                                 .Include(r => r.Veiculo)
                                 .ToListAsync();
        }

        public async Task CancelarReservaAsync(Guid reservaId)
        {
            var reserva = await _context.Reservas.FindAsync(reservaId);
            if (reserva != null)
            {
                reserva.Status = "Cancelada";
                _context.Reservas.Update(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Reserva> UpdateReservaAsync(Reserva updatedReserva)
        {
            var reserva = await _context.Reservas.FindAsync(updatedReserva.Id);
            if (reserva != null)
            {
                _context.Entry(reserva).CurrentValues.SetValues(updatedReserva);
                await _context.SaveChangesAsync();
            }
            return reserva;
        }

        public async Task<IEnumerable<Reserva>> GetReservasDisponiveisAsync()
        {
            return await _context.Reservas
                                 .Where(r => r.Status == "Confirmada")
                                 .Include(r => r.Cliente)
                                 .Include(r => r.Veiculo)
                                 .ToListAsync();
        }
    }
}
