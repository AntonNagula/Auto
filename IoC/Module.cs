using DomainCore.Interfaces;
using DomainService.Service;
using InfructructureDataInterfaces.Models;
using InfructructureDataInterfaces.Repositories;
using InfrustructureData.Data;
using InfrustructureData.Repositories;
using Ninject.Modules;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Ninject.Web.Common;
namespace IoC
{
    public class Module : NinjectModule
    {
        private string _connectionString;
        public Module(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public override void Load()
        {
            //Bind<IRepositories<RepoBuyer>>().To<BuyerRepository>().InThreadScope();
            //Bind<IRepositories<RepoCar>>().To<CarRepository>().InThreadScope();
            //Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();
            //Bind<IService>().To<Service>().InThreadScope();
            Bind<IRepositories<RepoBuyer>>().To<BuyerRepository>().InSingletonScope();
            Bind<IRepositories<RepoCar>>().To<CarRepository>().InSingletonScope();
            Bind<IRepositories<RepoBrands>>().To<BrandRepository>().InSingletonScope();
            Bind<IRepositories<RepoBuyCar>>().To<PurchaseRepository>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<IService>().To<Service>().InSingletonScope();
            //Bind<IAutoContext>.To<AutoContext>.InSingletonScope().WithConstructorArgument(GetOptions());
        }

        private DbContextOptions<AutoContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[_connectionString].ConnectionString;
            var options = new DbContextOptionsBuilder<AutoContext>()
                    .UseSqlServer(connectionString)
                    .Options;
            return options;
        }
    }
}
