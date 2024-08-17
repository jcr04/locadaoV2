using locadao.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Locadão.Infra.Repository.Alugueis;

public class AluguelRepository : IAluguelRepository
{
    private readonly LocadaoDbContext _context;

    public AluguelRepository(LocadaoDbContext context)
    {
        _context = context;
    }

    public async Task<Aluguel> AddAsync(Aluguel aluguel)
    {
        await _context.Alugueis.AddAsync(aluguel);
        await _context.SaveChangesAsync();
        return aluguel;
    }

    public async Task DeleteAsync(Guid id)
    {
        var aluguel = await _context.Alugueis.FindAsync(id);
        if (aluguel != null)
        {
            _context.Alugueis.Remove(aluguel);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Aluguel>> GetAlugueisDisponiveisAsync()
    {
        return await _context.Alugueis
                             .Include(a => a.Cliente)
                             .Include(a => a.Veiculo)
                             .Include(a => a.Agencia)
                             .Where(a => a.Status == "Disponível")
                             .ToListAsync();
    }

    public async Task<Aluguel> GetAluguelByIdAsync(Guid id)
    {
        return await _context.Alugueis
                            .Include(aluguel => aluguel.Cliente)
                            .Include(aluguel => aluguel.Veiculo)
                            .Include(aluguel => aluguel.Agencia)
                            .FirstOrDefaultAsync(aluguel => aluguel.Id == id);
    }
    public async Task<bool> IsVeiculoAlugadoAsync(Guid veiculoId)
    {
        return await _context.Alugueis.AnyAsync(a => a.VeiculoId == veiculoId && a.Status == "Ativo");
    }

    public async Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId)
    {
        return await _context.Alugueis
                            .Include(a => a.Veiculo)
                            .Include(a => a.Cliente)
                            .Where(a => a.AgenciaId == agenciaId)
                            .ToListAsync();
    }

}
