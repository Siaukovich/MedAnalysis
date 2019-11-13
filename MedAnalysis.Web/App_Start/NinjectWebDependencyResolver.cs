using DependencyResolver;
using Ninject;
using Ninject.Web.Common;

namespace MedAnalysis.Web
{
    public static class NinjectWebDependencyResolver
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        
        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        private static IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.ResolveKernel();
            return kernel;
        }
    }
 
}