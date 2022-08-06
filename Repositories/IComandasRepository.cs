using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Views.Comandas;

namespace ProvaSuficienciaWebII.Repositories
{
    public interface IComandasRepository
    {

        Task<List<ListarComandaViewModel>> Listar();
        Task<ObterComandaViewModel> ObterPorId(int id);
        Task<SalvarComandaViewModel> SalvarComanda(Comanda comanda);
    }
}
