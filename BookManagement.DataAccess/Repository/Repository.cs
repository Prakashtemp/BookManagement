using BookManagement.DataAccess.Repository.IRepository;
using BookManagement.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> dbSet;
        public Repository(ApplicationDbContext db) 
        {
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            //IQueryable<T> query = dbSet;
            //return query.ToList();
            return (dbSet); 
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }
        

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            //IQueryable<T> query = dbSet;
            //query = query.Where(filter);
            //return (query.FirstOrDefault());
            return dbSet.FirstOrDefault(filter);
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }
    }
}
