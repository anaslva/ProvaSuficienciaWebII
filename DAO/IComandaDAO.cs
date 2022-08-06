
using ProvaSuficienciaWebII.Entities;
using ProvaSuficienciaWebII.Results.Comandas;

namespace ProvaSuficienciaWebII.DAO
{
    public interface IComandaDAO
    {
        Task<List<ListarComandaResult>> ListagemComandas();
        Task<int> SalvarComanda(Comanda comanda);
       
    }
}
