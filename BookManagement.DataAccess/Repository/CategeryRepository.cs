using BookManagement.DataAccess.Repository.IRepository;
using BookManagement.Model;
using BookManagement.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Repository
{
    public class CategeryRepository : Repository<Categery>, ICategeryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategeryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Categery obj)
        {
            _db.Categeries.Update(obj); 
        }
        

        
    }
}
