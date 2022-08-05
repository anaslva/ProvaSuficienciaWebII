namespace ProvaSuficienciaWebII.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
