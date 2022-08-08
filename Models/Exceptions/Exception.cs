namespace ProvaSuficienciaWebII.Models.Exceptions
{
    public class Exception
    {
        public Exception(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; set; }
        public string Mensagem { get; set; }


    }
}
