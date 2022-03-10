using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategeryRepository ICategery_Obj { get; set; }
        ICoverTypeRepository ICoverType_Obj { get; set; }
        void Save();
    }
}
