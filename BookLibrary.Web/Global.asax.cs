using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BookLibrary.Web.App_Start;

namespace BookLibrary.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
