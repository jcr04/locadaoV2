using locadao.Domain.Models;
using locadao.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Locadão.Infra.Repository.Veiculos
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly LocadaoDbContext _context;

        public VeiculoRepository(LocadaoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> GetByIdAsync(Guid id)

        {
            return await _context.Veiculos.FindAsync(id);
        }

        public async Task<Veiculo> AddAsync(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            _context.Entry(veiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Veiculo> GetByPlacaAsync(string placa)
        {
            Veiculo? veiculo = await _context.Veiculos
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(v => v.Placa == placa);
            return veiculo;
        }

        public async Task<bool> PlacaExistsAsync(string placa)
        {
            return await _context.Veiculos.AnyAsync(v => v.Placa == placa);
        }

        public async Task<Veiculo> GetVeiculoAdaptadoDisponivelAsync(Guid agenciaId)
        {
            return await _context.Veiculos
                                 .FirstOrDefaultAsync(v => v.AgenciaId == agenciaId && v.DisponivelParaAluguel && v.AdaptadoParaPCD);
        }

        public async Task<bool> VerificarDisponibilidadeAsync(Guid veiculoId, DateTime dataInicio, DateTime dataFim)
        {
            // Verificar se existem reservas ou aluguéis que se sobrepõem às datas solicitadas para este veículo
            var reservasExistem = await _context.Reservas.AnyAsync(r =>
                r.VeiculoId == veiculoId &&
                ((r.DataInicio <= dataInicio && r.DataFim >= dataInicio) || (r.DataInicio >= dataInicio && r.DataInicio <= dataFim)));

            var alugueisExistem = await _context.Alugueis.AnyAsync(a =>
                a.VeiculoId == veiculoId &&
                ((a.DataInicio <= dataInicio && a.DataFim >= dataInicio) || (a.DataInicio >= dataInicio && a.DataInicio <= dataFim)));

            // Se houver sobreposição de datas em reservas ou aluguéis, o veículo não está disponível
            return !reservasExistem && !alugueisExistem;
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculosDisponiveisAsync()
        {
            return await _context.Veiculos
                                 .ToListAsync();
        }

    }
}
