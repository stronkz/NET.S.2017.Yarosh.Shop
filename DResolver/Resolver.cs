using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using IDataAccessLayer.Repos;
using Ninject;
using ORMEF;
using DataAccessLayer;
using System.Data.Entity;
using BuisnessLogicLayer.ConcreateServices;
using IBuisnessLogicLayer;

namespace DResolver
{
    public static class Resolver
    {
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {
        
            
                kernel.Bind<IRep<DALPurchase>>().To<PurchaseRep>().InSingletonScope();
                kernel.Bind<DbContext>().To<ShopModelContainer>().InSingletonScope();
            kernel.Bind<IRep<DALProduct>>().To<ProductRep>().InSingletonScope();

            kernel.Bind<IPurchaseServiece>().To<PurchaseService>();
            kernel.Bind<IShopServiece>().To<ShopService>();
        }
    }
}
