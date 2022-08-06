using ProvaSuficienciaWebII.DAO;
using ProvaSuficienciaWebII.Entities;
using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Views.Comandas;
using ProvaSuficienciaWebII.Views.Produtos;

namespace ProvaSuficienciaWebII.Handler
{
    public class ComandaHandler : IComandasHandler
    {
        private readonly IComandaDAO _comandasDao;

        public ComandaHandler(IComandaDAO dao)
        {
            _comandasDao = dao;
        }

        public async Task AtualizarComanda(AtualizarComanda comanda)
        {
            var comandaExistente = await _comandasDao.ObterComanda(comanda.Id);

            var comandaAtualizada = new Comanda()
            {
                Id = comanda.Id,
                IdUsuario = comanda.IdUsuario > 0 ? comanda.IdUsuario : comandaExistente.IdUsuario,
                NomeUsuario = comanda.NomeUsuario ?? comandaExistente.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario ?? comandaExistente.TelefoneUsuario,
                Produtos = new List<Entities.Produto>()
            };

            if(comanda.Produtos != null)
            {
                if (comanda.Produtos.Any())
                {
                    foreach(var p in comanda.Produtos)
                    {
                        var produto = comandaExistente.Produtos.Find(x => x.Id == p.Id);

                        if(produto != null)
                        {
                            var produtoAtualizar = new Entities.Produto()
                            {
                                Id = p.Id,
                                Nome = p.Nome,
                                Preco = p.Preco
                            };

                            comandaAtualizada.Produtos.Add(produtoAtualizar);

                        } 
                    }
                }
            }

            await _comandasDao.AtualizarComanda(comandaAtualizada);

        }

        public async Task<DeletarComandaViewModel> DeletarComanda(int id)
        {
            var comanda = await _comandasDao.ObterComanda(id);

            var comandaDeletar = new Entities.Comanda()
            {
                Id = id,
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos?.Select(x => new Entities.Produto()
                           {
                               Id = x.Id,
                               Nome = x.Nome, 
                               Preco = x.Preco,
                           }).ToList()
            };
            await _comandasDao.DeletarComanda(comandaDeletar);

            return new DeletarComandaViewModel
            {
                Success = new Success
                {
                    Text = "comanda removida",
                },
            };
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

        public async Task<ObterComandaViewModel> ObterPorId(int id)
        {
            var comanda = await _comandasDao.ObterComanda(id);

            if(comanda != null)
            {
                var retorno = new ObterComandaViewModel()
                {
                    IdUsuario = comanda.IdUsuario,
                    NomeUsuario = comanda.NomeUsuario,
                    TelefoneUsuario = comanda.TelefoneUsuario,
                    Produtos = comanda.Produtos != null ? comanda.Produtos
                    .Select(x => new ObterProdutoViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToList() : null
                };
                return retorno;

            } else
            {
                return null;
            }
        }

        public async Task<SalvarComandaViewModel> SalvarComanda(SalvarComanda comanda)
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
