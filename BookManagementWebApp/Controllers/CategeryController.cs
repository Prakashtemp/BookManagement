using BookManagement.DataAccess.Repository.IRepository;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementWebApp.Controllers
{
    public class CategeryController : Controller
    {
        private readonly ICategeryRepository _db;

        public CategeryController(ICategeryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categery> obj=_db.GetAll();
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
                _db.Add(obj);
                _db.Save();
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
            var obj = _db.GetFirstOrDefault(x=>x.Id==id);

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
                _db.Update(obj);
                _db.Save();
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
            var obj = _db.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
