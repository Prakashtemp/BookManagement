using BookManagement.DataAccess.Repository.IRepository;
using BookManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementWebApp.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CoverTypeController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        // GET: CoverTypeController
        public IActionResult Index()
        {
            IEnumerable<CoverType> obj = _UnitOfWork.ICoverType_Obj.GetAll();
            return View(obj);
        }
      
        // GET: CoverTypeController/Details/5
        //public IActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: CoverTypeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoverTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.ICoverType_Obj.Add(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: CoverTypeController/Edit/5
        public IActionResult Edit(int ?id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var obj = _UnitOfWork.ICoverType_Obj.GetFirstOrDefault(x => x.Id == id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: CoverTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.ICoverType_Obj.Update(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: CoverTypeController/Delete/5
        public IActionResult Delete(int ?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _UnitOfWork.ICoverType_Obj.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.ICoverType_Obj.Remove(obj);
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        //// POST: CoverTypeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
