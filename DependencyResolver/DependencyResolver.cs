using MedAnalysis.Core;
using MedAnalysis.Core.Interfaces;
using MedAnalysis.DataAccess.Core;
using MedAnalysis.DataAccess.EF;
using MedAnalysis.DataAccess.File;
using Ninject;

namespace DependencyResolver
{
    public static class DependencyResolver
    {
        public static void ResolveKernel(this IKernel kernel, bool useDatabaseAsStorage = true)
        {
            kernel.Bind<IAnalysisService>().To<AnalysisService>().InSingletonScope();

            if (useDatabaseAsStorage)
            {
                kernel.Bind<IAnalysisRepository>().To<AnalysisRepositoryEF>().InSingletonScope();
            }
            else
            {
                kernel.Bind<IAnalysisRepository>().To<AnalysisRepositoryFile>().InSingletonScope();
            }
        }
    }
}
