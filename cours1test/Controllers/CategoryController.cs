using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cours1test.Models;
using cours1test.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace cours1test.Controllers
{
    public class CategoryController : Controller
    {

        private readonly FanficContextDB _db;
        private readonly UserContext _userDb;


        public CategoryController(FanficContextDB context, UserContext userContext)
        {
            _db = context;
            _userDb = userContext;
        }

        public IActionResult Index() => View(_db.Categories.ToList());

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create() => View();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete() => View();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit() => View();


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _db.Categories.Remove(_db.Categories.Where(g => g.ID == id).First());
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
          
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Category model)
        {
            if (!CheckFD(model))
            {
                _db.Categories.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Category");
            }
            else return Content("ERROR");
        }



        private bool CheckFD(Category model)
        {
            var result = _db.Categories.Where(g => g.Name == model.Name).ToList();
            if (result.Count > 0) return true;
            else return false;
        }
    }
}
