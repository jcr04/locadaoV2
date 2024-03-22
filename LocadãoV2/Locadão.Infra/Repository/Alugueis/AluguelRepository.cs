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

    public async Task<Aluguel> GetAluguelByIdAsync(Guid id)
    {
        return await _context.Alugueis
            .Include(aluguel => aluguel.Cliente)
            .Include(aluguel => aluguel.Veiculo)
            .Include(aluguel => aluguel.Agencia)
            .FirstOrDefaultAsync(aluguel => aluguel.Id == id);
    }
}
