using BookManagement.DataAccess.Data;
using BookManagement.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            ICategery_Obj = new CategeryRepository(db);
            ICoverType_Obj = new CoverTypeRepository(db);
        }
        public ICategeryRepository ICategery_Obj { get; set; }
        public ICoverTypeRepository ICoverType_Obj { get ; set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
