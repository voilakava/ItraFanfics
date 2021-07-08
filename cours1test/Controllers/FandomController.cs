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


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _db.Fandom.Remove(_db.Fandom.Where(g => g.ID == id).First());
            _db.SaveChanges();
            return RedirectToAction("Index", "Fandom");
        }

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
            //_db.Fandoms.Remove(_db.Fandoms.Where(g => g.ID == id).First());
            //_db.SaveChanges()аш;
            //return RedirectToAction("Index", "Fandom");


            //var result = _db.Fandoms.Where(f => f.ID == model.ID).FirstOrDefault();
            //if (result != null)
            //{
            //    result.Titile = model.Titile;
            //    result.Author = model.Author;

            //    _db.SaveChanges();
            //    return View(model);
            //}
            //return NotFound();
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


        //похожий код для изменения коллекции

        //[HttpGet]
        //public IActionResult EditGame(int id)
        //{
        //    Game game = _db.Games.Find(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    EditGameViewModel model = new EditGameViewModel { Name = game.Name, Genre = game.Genre, Publisher = game.Publisher, Price = game.Price };
        //    return View(model);
        //}


        //тут отображать надо придумать КАК все фанфики данного фандома

        private bool CheckFD(Fandom model)
        {
            var result = _db.Fandom.Where(g => g.Titile == model.Titile).ToList();
            if (result.Count > 0) return true;
            else return false;
        }

        //public async Task<IActionResult> Edit(string title, string author) { }


        //private List<Fandom> _libraryList => _db.Fanfics.Where(l => l.Fandom == CurrentUser.Id).ToList();

        //private List<Fandom> _fandomFanficList
        //{
        //    get
        //    {
        //        try
        //        {
        //            return JsonSerializer.Deserialize<List<Fandom>>(_libraryList.Last().GamesID);
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}


    }
}
