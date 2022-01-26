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
    public class FandomController : Controller
    {

        private readonly FanficContextDB _db;
        private readonly UserContext _userDb;

        public FandomController(FanficContextDB context, UserContext userContext)
        {
            _db = context; 
            _userDb = userContext;
        }
        [HttpGet]
         public IActionResult Index() => View(_db.Fandom.ToList());

        
        //public IActionResult AllFanfics() => View(_fandomFanficList);

        //[HttpGet]
        //public IActionResult GamesList() => View(_db.Games.OrderBy(g => g.Name).ToList());
         

        //public IActionResult Create() => View();




        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create() => View();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete() => View();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit() => View();

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var fandom = _db.Fandom.Where(g => g.ID == id).First();
            _db.Fandom.Remove(fandom);
            var fanfics = _db.Fanfics.Where(f => f.Fandom == fandom);
            foreach(var f in fanfics)
            {
                _db.Fanfics.Remove(f);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Fandom");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add(AddFandomModel model)
        {
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {

            var fd = _db.Fandom.Where(g => g.ID == id).ToList().First();
            if (fd == null)
            {
                return NotFound();
            }
            EditFandomModel model = new EditFandomModel { Id = fd.ID, Title = fd.Titile, Author = fd.Author };
            return View(model);
           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Fandom fandom)
        {
            _db.Fandom.Update(fandom);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Fandom model)
        {
            if (!CheckFD(model))
            {
                _db.Fandom.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Fandom");
            }
            else return Content("ERROR");
        }

         

        private bool CheckFD(Fandom model)
        {
            var result = _db.Fandom.Where(g => g.Titile == model.Titile).ToList();
            if (result.Count > 0) return true;
            else return false;
        }
         

    }
}
