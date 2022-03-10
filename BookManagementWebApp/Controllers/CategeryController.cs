using BookManagement.DataAccess.Repository.IRepository;
using BookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementWebApp.Controllers
{
    public class CategeryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CategeryController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Categery> obj= _UnitOfWork.ICategery_Obj.GetAll();
            return View(obj);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categery obj)
        {
            
            if(obj.Name.ToString().Length<5)
            {
                ModelState.AddModelError("name", "Name length must be 6");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.ICategery_Obj.Add(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Edit(int ?id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var obj = _UnitOfWork.ICategery_Obj.GetFirstOrDefault(x=>x.Id==id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categery obj)
        {

            if (obj.Name.ToString().Length < 5)
            {
                ModelState.AddModelError("name", "Name length must be 6");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.ICategery_Obj.Update(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _UnitOfWork.ICategery_Obj.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.ICategery_Obj.Remove(obj);
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
