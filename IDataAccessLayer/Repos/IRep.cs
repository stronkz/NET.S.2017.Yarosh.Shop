using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer.Repos
{
    public interface IRep<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int key);
        T GetByPredicate(Expression<Func<T, bool>> f);
        void Create(T e);
        void Delete(T e);
        void Update(T entity);
    }
}
