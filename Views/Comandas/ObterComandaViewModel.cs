using ProvaSuficienciaWebII.Views.Produtos;

namespace ProvaSuficienciaWebII.Views.Comandas
{
    public class ObterComandaViewModel
    {
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string TelefoneUsuario { get; set; }

        public List<ObterProdutoViewModel> Produtos { get; set; }
    }
}
