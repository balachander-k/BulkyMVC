
using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Catgories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Catgories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id )
        {
            Category? obj = _db.Catgories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Catgories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Categroy Deleted Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Catgories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catgories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Categroy Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Catgories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Categroy Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
