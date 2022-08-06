using ProvaSuficienciaWebII.Views.Produtos;

namespace ProvaSuficienciaWebII.Views.Comandas
{
    public class SalvarComandaViewModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<SalvarProdutoViewModel> Produtos { get; set; }
    }
}
