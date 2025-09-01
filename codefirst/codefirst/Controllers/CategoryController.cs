using codefirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace codefirst.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductContext _context;
        public CategoryController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> lstcategories = _context.Categories.ToList();
            return View(lstcategories);
        }
        public IActionResult Details(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);           
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(int id,Category category)
        {
            Category extcategory = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            extcategory.CategoryName = category.CategoryName;
            //_context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id, Category category)
        {
            Category extcategory = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
           
            _context.Categories.Remove(extcategory);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
