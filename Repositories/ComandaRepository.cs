using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Models;

namespace ProvaSuficienciaWebII.Repositories
{
    public class ComandaRepository : IComandasRepository
    {
        private readonly Context _context;

        public ComandaRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comanda>> GetAllAsync()
        {
            return await _context.Comandas.Include(x => x.Produtos).ToListAsync();
        }

        public async Task<Comanda?> GetByIdAsync(int id)
        {
            return await _context.Comandas.Include(x => x.Produtos).FirstOrDefaultAsync();
        }
    }
}
