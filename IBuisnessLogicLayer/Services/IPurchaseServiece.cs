using IBuisnessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuisnessLogicLayer
{
    public interface IPurchaseServiece
    {
        IEnumerable<ProductEntity> GetAllProducts();
        ProductEntity GetProduct(int id);
        void AddProduct(ProductEntity product);
        void DeleteProduct(ProductEntity product);
    }
}
