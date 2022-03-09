using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Repository.IRepository
{
    public interface ICategeryRepository : IRepository<Categery>
    {
        void Update(Categery obj);
        void Save();
    }
}
