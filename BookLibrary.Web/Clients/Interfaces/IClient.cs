namespace BookLibrary.Web.Clients.Interfaces
{
    public interface IClient
    {
        T Get<T>(string url) where T : class;

        bool Create<T>(string url, T dto) where T : class;

        bool Update<T>(string url, T dto) where T : class;

        bool Delete(string url);
    }
}
