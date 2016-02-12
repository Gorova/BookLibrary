using System.Web.Mvc;
using BookLibrary.Web.Clients;
using BookLibrary.Web.Clients.Interfaces;

namespace BookLibrary.Web.Controllers
{
    public class BaseController: Controller 
    {
        protected readonly IClient client;

        protected BaseController()
        {
            this.client = new WebApiClient();
        } 
    }
}