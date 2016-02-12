using System.Web.Http;
using BookLibrary.Bootstrap;
using Library.DAL.API.Repositories;
using Ninject;

namespace BookLibrary.WebApi.Controllers
{
    public abstract class BaseController: ApiController
    {
        protected readonly IRepository repository;

        protected BaseController()
        {
            var kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }
    }
}
