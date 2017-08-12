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
        T GetById(int id);
        T GetByPredicate(Expression<Func<T, bool>> func);
        void Create(T pr);
        void Delete(T pr);
        void Update(T pr);
        void Commit();
    }
}
