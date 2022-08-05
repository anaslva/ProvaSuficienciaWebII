using ProvaSuficienciaWebII.Models;

namespace ProvaSuficienciaWebII.Repositories
{
    public interface IComandasRepository
    {

        Task<IEnumerable<Comanda>> GetAllAsync();
        Task<Comanda?> GetByIdAsync(int id);
    }
}
