using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
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
            PurchaseEntity purch1 = new PurchaseEntity() { BuyerName = "buyer1" };

            PurchaseEntity purch2 = new PurchaseEntity() { BuyerName = "buyer2" };

            ProductEntity pr1 = new ProductEntity()
            { Amount = 4, Category = "toys", Description = "prod1", Price = 10.0M, ProductsName = "PRODUCT1", Buyer = "buyer1" };
            ProductEntity pr2 = new ProductEntity()
            { Amount = 1, Category = "toys", Description = "prod2", Price = 20.0M, ProductsName = "PRODUCT2", Buyer = "buyer1" };

            ProductEntity pr3 = new ProductEntity()
            { Amount = 10, Category = "fruits", Description = "prod3", Price = 30.0M, ProductsName = "PRODUCT3", Buyer = "buyer2" };

            ProductEntity prtodel = new ProductEntity()
                { Amount = 4, Category = "toys", Description = "proddd1", Price = 10.0M, ProductsName = "PRODUCTToDELETE", Buyer = "buyer1" };


            var shop = resolver.Get<IShopServiece>();
            
            //shop.RegisterPurchase(purch1);
            //shop.RegisterPurchase(purch2);

            //shop.AddProductToShop(pr1);
            //shop.AddProductToShop(pr2);
            //shop.AddProductToShop(pr3);

            var list = shop.GetAllProducts();
            foreach (var prod in list)
            {
                Console.WriteLine(prod.ProductsName+"  "+prod.Category + "  " + prod.Buyer);
            }

            var purchlist = shop.GetAllPurchases();
            foreach (var purch in purchlist)
            {
                Console.WriteLine(purch.BuyerName);
                foreach (var prod in purch.Products)
                {
                    Console.WriteLine(prod.ProductsName);
                }
               
            }
            //Console.WriteLine(shop.GetProduct(2).ProductsName);
            Console.WriteLine(shop.GetPurchase(4).BuyerName);

            //shop.DeleteProductFromShop(pr2);
            shop.DeleteProductFromShop(prtodel);
            Console.ReadKey();
        }

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }
    }
}
