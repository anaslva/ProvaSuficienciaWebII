using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Entities;
using ProvaSuficienciaWebII.Results.Comandas;

namespace ProvaSuficienciaWebII.DAO
{
    public class ComandaDAO : IComandaDAO
    {

        private readonly Context _context;
        private readonly DbSet<Comanda> _c;

        public ComandaDAO(Context context)
        {
            _context = context;
            _c = _context.Set<Comanda>();
        }
        public async Task<List<ListarComandaResult>> ListagemComandas()
        {
            return await _c
              .Select(x => new ListarComandaResult
              {
                  IdUsuario = x.IdUsuario,
                  NomeUsuario = x.NomeUsuario,
                  TelefoneUsuario = x.TelefoneUsuario,
              })
              .ToListAsync();
        }

        public async Task<int> SalvarComanda(Comanda comanda)
        {
            var salvo = _c.Add(comanda).Entity;
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
