
using ProvaSuficienciaWebII.Entities;
using ProvaSuficienciaWebII.Results.Comandas;

namespace ProvaSuficienciaWebII.DAO
{
    public interface IComandaDAO
    {
        Task<List<ListarComandaResult>> ListagemComandas();
        Task<ObterComandaResult> ObterComanda(int id);
        Task<int> SalvarComanda(Comanda comanda);
        Task AtualizarComanda(Comanda comanda);
        Task DeletarComanda(Comanda comanda);
       
    }
}
