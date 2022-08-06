using ProvaSuficienciaWebII.Results.Produtos;

namespace ProvaSuficienciaWebII.Results.Comandas
{
    public class ObterComandaResult
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<ObterProdutoResult> Produtos { get; set; }
    }
}
