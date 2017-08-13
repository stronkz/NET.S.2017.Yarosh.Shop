using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogicLayer.ConcreateServices;
using DResolver;
using IBuisnessLogicLayer;
using IBuisnessLogicLayer.Entities;
using Ninject;

namespace ConsoleShop
{
    class Program
    {
        private static readonly IKernel resolver;
        static void Main(string[] args)
        {
            ProductEntity pr1=new ProductEntity()
                 { Amount = 4,Category = 1,Description = "prod1",Price = 10.0M,ProductsName = "PRODUCT1"};
            ProductEntity pr2 = new ProductEntity()
                 { Amount = 1, Category = 4, Description = "prod2", Price = 20.0M, ProductsName = "PRODUCT2" };

            ProductEntity pr3 = new ProductEntity()
                { Amount = 10, Category = 2, Description = "prod3", Price = 30.0M, ProductsName = "PRODUCT3" };


            var shop = resolver.Get<IShopServiece>();
            
            shop.AddProductToShop(pr1);
            shop.AddProductToShop(pr2);
            shop.AddProductToShop(pr3);

            var list = shop.GetAllProducts();
            foreach (var prod in list)
            {
                Console.WriteLine(prod.ProductsName);
            }

            Console.ReadKey();
        }

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }
    }
}
