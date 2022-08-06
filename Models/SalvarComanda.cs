namespace ProvaSuficienciaWebII.Models
{
    public class SalvarComanda
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
