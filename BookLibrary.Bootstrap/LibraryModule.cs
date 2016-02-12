using System.Data.Entity;
using BookLibrary.DAL.Repositories;
using Library.DAL;
using Library.DAL.API.Repositories;
using Ninject.Modules;

namespace BookLibrary.Bootstrap
{
    public class LibraryModule : NinjectModule
    {
        public override void Load()
        {
            this.InitializeRepositorirs();
        }

        private void InitializeRepositorirs()
        {
            Bind<DbContext>().To<BookLibraryContext>();
            Bind<IRepository>().To<Repository>();
        }
    }
}
