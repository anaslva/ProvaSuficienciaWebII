using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Views.Comandas;

namespace ProvaSuficienciaWebII.Handler
{
    public interface IComandasHandler
    {

        Task<List<ListarComandaViewModel>> Listar();
        Task<ObterComandaViewModel> ObterPorId(int id);
        Task<SalvarComandaViewModel> SalvarComanda(SalvarComanda comanda);
        Task AtualizarComanda(AtualizarComanda comanda);
        Task<DeletarComandaViewModel> DeletarComanda(int id);
    }
}
