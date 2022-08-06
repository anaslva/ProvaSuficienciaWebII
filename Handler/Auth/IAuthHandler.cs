namespace ProvaSuficienciaWebII.Handler.Auth
{
    public interface IAuthHandler
    {
        (string, DateTime) GerarAuth();
    }
}
