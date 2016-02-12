using System.Web;
using System.Web.Http;
using BookLibrary.Bootstrap;

namespace BookLibrary.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperEntityDtoConfig.RegisterMapping();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
