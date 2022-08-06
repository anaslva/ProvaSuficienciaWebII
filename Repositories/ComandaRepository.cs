
using ProvaSuficienciaWebII.DAO;
using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Views.Comandas;
using ProvaSuficienciaWebII.Views.Produtos;

namespace ProvaSuficienciaWebII.Repositories
{
    public class ComandaRepository : IComandasRepository
    {
        private readonly IComandaDAO _comandasDao;

        public ComandaRepository(IComandaDAO dao)
        {
            _comandasDao = dao;
        }
    

        public async Task<List<ListarComandaViewModel>> Listar()
        {
            var comandas = await _comandasDao.ListagemComandas();

            return comandas
                .Select(x => new ListarComandaViewModel
                {
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                }).ToList();
        }
 
        public Task<ObterComandaViewModel> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SalvarComandaViewModel>  SalvarComanda(Comanda comanda)
        {

            var salvarComanda = new Entities.Comanda
            {
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos
                   .Select(x => new Entities.Produto
                   {
                       Id = x.Id,
                       Nome = x.Nome,
                       Preco = x.Preco,
                   })
                   .ToList(),
            };
                
            var id = await _comandasDao.SalvarComanda(salvarComanda);

            var retorno = new SalvarComandaViewModel()
            {
                Id = id,
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos
                    .Select(x => new SalvarProdutoViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToList()
            };

            return retorno;
    
        }
    }
}
