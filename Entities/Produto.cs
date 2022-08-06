namespace ProvaSuficienciaWebII.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public int IdComanda { get; set; }

        public Comanda Comanda { get; set; }
    }
}
