using Ninject;

namespace BookLibrary.Bootstrap
{
    public static class Kernel
    {
        public static StandardKernel Initialize()
        {
            return new StandardKernel(new LibraryModule());
        }
    }
}
