using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBuisnessLogicLayer;
using IBuisnessLogicLayer.Entities;
using IDataAccessLayer.Repos;
using IDataAccessLayer;
using BuisnessLogicLayer.Mappers;

namespace BuisnessLogicLayer.ConcreateServices
{
    public class PurchaseService : IPurchaseServiece
    {
        private readonly PurchaseEntity purchase;
        private readonly IRep<DALPurchase> repository;
        

        public PurchaseService(IRep<DALPurchase> repository)
        {
            this.repository = repository;
            purchase=new PurchaseEntity(){BuyerName = "ddddd",Products =new List<ProductEntity>()};
        }

       

        public void AddProduct(ProductEntity product)
        {
            purchase.Products.Add(product);
            
        }

        public void DeleteProduct(ProductEntity product)
        {
            purchase.Products.Remove(product);
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return purchase.Products;
        }

        public void Buy()
        {
            repository.Create(purchase.ToDallPurchase());
            repository.Commit();
        }
    }
}
