using HotelListing.IRepository;
using HotelListing.Repository;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using System.Web.Http;

namespace HotelListing.App_Start
{
    public class NinjectWebCommon
    {
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
