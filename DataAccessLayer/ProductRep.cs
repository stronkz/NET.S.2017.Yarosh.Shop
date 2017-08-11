using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer.Repos;
using IDataAccessLayer;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class ProductRep : IRep<DALProduct>
    {
        public void Create(DALProduct e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DALProduct e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public DALProduct GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DALProduct GetByPredicate(Expression<Func<DALProduct, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DALProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
