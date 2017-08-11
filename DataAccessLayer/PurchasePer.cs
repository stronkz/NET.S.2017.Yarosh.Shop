using IDataAccessLayer;
using IDataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    class PurchasePer : IRep<DALPurchase>
    {
        public void Create(DALPurchase e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DALPurchase e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALPurchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public DALPurchase GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DALPurchase GetByPredicate(Expression<Func<DALPurchase, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DALPurchase entity)
        {
            throw new NotImplementedException();
        }
    }
}
