using locadao.Domain.Models;
using locadao.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Locadão.Infra.Repository.Agencias;

public class AgenciaRepository : IAgenciaRepository
{
    private readonly LocadaoDbContext _context;

    public AgenciaRepository(LocadaoDbContext context)
    {
        _context = context;
    }


    public async Task<Agencia> AddAsync(Agencia agencia)
    {
        await _context.Agencias.AddAsync(agencia);
        await _context.SaveChangesAsync();
        return agencia;
    }

    public async Task DeleteAsync(Guid id)
    {
        var agencia = await _context.Agencias.FindAsync(id);
        if (agencia != null)
        {
            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();
        }


    }

    public async Task<Agencia> GetAgenciaByIdAsync(Guid id)
    {
        return await _context.Agencias.FindAsync(id);
    }
}
