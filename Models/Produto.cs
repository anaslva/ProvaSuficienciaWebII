namespace ProvaSuficienciaWebII.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public int ComandaId { get; set; }

        public Comanda Comanda { get; set; }
    }
}
