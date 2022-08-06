using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Entities;
using ProvaSuficienciaWebII.Results.Comandas;
using ProvaSuficienciaWebII.Results.Produtos;

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

        public async Task AtualizarComanda(Comanda comanda)
        {
            _c.Update(comanda);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarComanda(Comanda comanda)
        {
            _c.Remove(comanda);
            await _context.SaveChangesAsync();
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

        public Task<ObterComandaResult?> ObterComanda(int id)
        {
            return _c
                .Include(x => x.Produtos)
                .Where(x => x.Id == id)
                .Select(x => new ObterComandaResult
                {
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                    Produtos = x.Produtos
                        .Select(y => new ObterProdutoResult
                        {
                            Id = y.Id,
                            Nome = y.Nome,
                            Preco = y.Preco,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarComanda(Comanda comanda)
        {
            var salvo = _c.Add(comanda).Entity;
            await _context.SaveChangesAsync();
            return salvo.Id;
        }
    }
}
