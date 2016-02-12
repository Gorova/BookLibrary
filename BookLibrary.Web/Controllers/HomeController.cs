using System.Web.Mvc;

namespace BookLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Book");
        }
    }
}