using System.Configuration;

namespace BookLibrary.Web.Clients
{
    public static class UrlProvider
    {
        public static string WebApiHost = ConfigurationManager.AppSettings["WebApiHost"];

        public static string WebApiBook = ConfigurationManager.AppSettings["WebApiBook"];

        public static string WebApiCategory = ConfigurationManager.AppSettings["WebApiCategory"];

        public static string WebApiReport = ConfigurationManager.AppSettings["WebApiReport"];
    }
}