using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter); 
        void Remove(T item);
    }
}
