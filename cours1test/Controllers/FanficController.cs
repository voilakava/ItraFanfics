using System;
using System.IO;
using System.Threading.Tasks;
using cours1test.Models;
using cours1test.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using Korth.EasyQuery.Linq;
using System.Text.Json;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using static cours1test.Helper;

namespace cours1test.Controllers
{
    public class FanficController : Controller
    {

        private readonly FanficContextDB _db;
        private readonly UserContext _userDb;
        private readonly UserManager<User> _userManager;


        public FanficController(FanficContextDB context, UserContext userContext, UserManager<User> userManager)
        {
            _db = context;
            _userDb = userContext;
            _userManager = userManager;
        }

        internal static ICollection<PostLike> GetLikes(Fanfic f)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            //var model = new AddFanficModel();
            //var fandomList = _db.Fandoms.ToList();
            //ViewBag.FandomList = new SelectList(_db.Fandom, "ID", "Titile", "Author");
             
            var fandoms = _db.Fandom.ToList();
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (Fandom item in fandoms)
            {
                stateList.Add(new SelectListItem
                {
                    Text = item.Titile,
                    Value = item.ID.ToString(),

                });
            }
            ViewBag.Fandom = stateList;
            return View( );
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditFanfic(int Id)
        {
            var fandoms = _db.Fandom.ToList();
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (Fandom item in fandoms)
            {
                stateList.Add(new SelectListItem
                {
                    Text = item.Titile,
                    Value = item.ID.ToString(),

                });
            }
            ViewBag.Fandom = stateList;
            var chapters = _db.Chapters.Where(c => c.FanficId == Id).ToList();
            Fanfic fanfic = _db.Fanfics.Where(f => f.ID == Id).First();
            fanfic.Chapters = chapters.OrderByDescending(s => s.RangeId).ToList();

            return View(fanfic);
        }

        [HttpPost]
        public async Task<object> EditFanfic(Fanfic fanficModel)
        {
            Console.WriteLine("Fanfic Id Edit = " + fanficModel.ID);

            try
            {
                int fandomId = Convert.ToInt32(fanficModel.FandomName);
                fanficModel.Fandom = _db.Fandom.Where(f => f.ID == fandomId).First();
                var fanfic = _db.Fanfics.First(f => f.ID == fanficModel.ID);

                fanfic.Title = fanficModel.Title;
                fanfic.Description = fanficModel.Description;
                fanfic.FandomName = fanficModel.FandomName;
                fanfic.Fandom = fanficModel.Fandom;
                _db.SaveChanges();
                Console.WriteLine("Сохранены изменения фанфика со старым id "+ fanficModel.ID);
            }
            catch
            {
                Console.WriteLine("Не удалось сохранить");
            }

            return RedirectToAction("Readfic", "Fanfiction", new { id = fanficModel.ID }); 
        }

        private Fanfic GetFanfic()
        {
            Fanfic fanfic = new Fanfic();
            return fanfic;
        }

        public ICollection<Chapter> GetChapters()
        {
            List<Chapter> chapters = new List<Chapter>();
            return chapters;
        }

        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //public IActionResult Delete() => View();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit() => View();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {

            return View();
        }


        //[HttpGet]
        //public ActionResult FandomEntry()
        //{
        //    string const = _db.
        //}

        //это для скачивания

        //public IActionResult GetFile()
        //{
        //    // Путь к файлу
        //    string file_path = Path.Combine(_db.ContentRootPath, "Files/book.pdf");
        //    // Тип файла - content-type
        //    string file_type = "application/pdf";
        //    // Имя файла - необязательно
        //    string file_name = _db.Fanfics.Find().Title;
        //    return PhysicalFile(file_path, file_type, file_name);
        //}


        //[HttpPost] 
        //public async Task<IActionResult> Index
        //{

        //}

        ////для создания фанфика
        ///

        [HttpPost]
        public async Task<IActionResult> Create(Fanfic model)
        { 
            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine("Из вью id и name" + model.Fandom + " , " + model.FandomName);


            //var userId = user.Id;
            try
            {
                int fandomId = Convert.ToInt32(model.FandomName);
                model.Fandom = _db.Fandom.Where(f => f.ID == fandomId).First();
                model.AuthorId = user.Id;
            }
            catch
            {
                Console.WriteLine();
            }
            //Chapter firsrChapter = new Chapter();
            //firsrChapter.CName = "Пролог";
            //firsrChapter.CText = model.FText;
            //firsrChapter.FanficID = model.ID;
            //_db.Chapters.Add(firsrChapter);
            //await _db.SaveChangesAsync();
            //model.Chapters.Add(_db.Chapters.Where(b=>b.FanficID == model.ID).First());
            
            _db.Fanfics.Add(model);
            
            
            await _db.SaveChangesAsync();

            Console.WriteLine("model Id" + model.ID);

            return RedirectToAction("EditFanfic", new {  id = model.ID });
             
        }

        [HttpGet]
        public IActionResult AddChapter(int Id)
        {


            Chapter chapterModel = new Chapter(); 
            chapterModel.FanficId = Id;

            return PartialView("AddChapter", chapterModel);
        }

        [HttpGet]
        public async Task<IActionResult> ClickLike(int fanficId)
        {
            Random rand = new Random();
            var user = await _userManager.GetUserAsync(User); 
            PostLike like = new PostLike();
            //like.ID = rand.Next(1000000);
            like.UserId = user.Id;
            like.FanficId = fanficId;
            like.Liked = true;
            Console.WriteLine("Сохранение в бд с id фанфика = " + fanficId);  
            _db.Likes.Add(like);
            await _db.SaveChangesAsync();

            return RedirectToAction("ReadFic", "Fanfiction", new { id = fanficId });

        }

        [HttpGet]
        public async Task<IActionResult> ClickDislike(int fanficId)
        {

            var user = await _userManager.GetUserAsync(User);
            PostLike like = new PostLike();

            like =  _db.Likes.Where(l => l.UserId == user.Id && l.FanficId == fanficId).First();
            _db.Likes.Remove(like);
            _db.SaveChanges();

            return RedirectToAction("ReadFic", "Fanfiction", new { id = fanficId });

        }
        [HttpGet]
        public async Task<IActionResult> AddBookmark(int fanficId)
        {
            var user = await _userManager.GetUserAsync(User);
            Bookmark bookmark = new Bookmark();
            bookmark.UserId = user.Id;
            bookmark.FanficId = fanficId;
            bookmark.InBookmarks = true;
            Console.WriteLine("Сохранение в бд закладки с id фанфика = " + fanficId);
            _db.Bookmarks.Add(bookmark);
            _db.SaveChanges();

            return RedirectToAction("ReadFic", "Fanfiction", new { id = fanficId });

        }
        
        [HttpGet]
        public async Task<IActionResult> RemoveBookmark(int fanficId)
        {

            var user = await _userManager.GetUserAsync(User);
            Bookmark bookmark = new Bookmark();
            bookmark = _db.Bookmarks.Where(l => l.UserId == user.Id && l.FanficId == fanficId).First();
            _db.Bookmarks.Remove(bookmark);
            _db.SaveChanges();

            return RedirectToAction("ReadFic", "Fanfiction", new { id = fanficId });

        }

        //[NoDirectAccess]


        [HttpGet]
        [Authorize]
        [NoDirectAccess]
        public IActionResult AddComment(int fanficId)
        { 
            Console.WriteLine("новый коммент fanficId=" + fanficId);
            try
            {
                Comment commentModel = new Comment();
                commentModel.FanficId = fanficId;
                return View(commentModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditChapter(int fanficId,int id = 0 )
        {
            
            if (id == 0)
            {
                
                var chapterModel = new Chapter(); 
                chapterModel.FanficId = fanficId;
                chapterModel.RangeId = _db.Chapters.Where(c => c.FanficId == fanficId).Count() + 1;
                return View(chapterModel);
            } 
            else
            {
                Console.WriteLine("вызвался метод с id!=0");
                Console.WriteLine("новый fanficId=" + fanficId);
                var chapterModel = await _db.Chapters.FindAsync(id);
                if (chapterModel == null)
                {
                    return NotFound();
                }
                return View(chapterModel);
            }
        }

         

        [HttpPost]
        public async Task<IActionResult> AddOrEditChapter(Chapter chapterModel)
        {

            //if (chapterModel.ID != null)
            //{
                try
                {
                    var chapter = _db.Chapters.First(c => c.ID == chapterModel.ID);
                    chapter.CText = chapterModel.CText;
                    chapter.CName = chapterModel.CName;
                    chapter.RangeId = chapterModel.RangeId;
                    _db.SaveChanges();
                    Console.WriteLine("Сохранила изменения в бд с chapterID = " + chapterModel.ID);

                }
                catch
                {
                    Console.WriteLine("Сохранила новую главу?Й?Й " + chapterModel.ID);

                    _db.Chapters.Add(chapterModel);
                    await _db.SaveChangesAsync();
                }
                
                
            //}
            //else
            //{
            //    Console.WriteLine("Сохранила новую главу?Й?Й " + chapterModel.ID);

            //    _db.Chapters.Add(chapterModel);
            //    await _db.SaveChangesAsync();
            //}
            


            Console.WriteLine("Должен сохранить FanficId из модели = "+ chapterModel.FanficId);

            
            //Fanfic fanfic =_db.Fanfics.Where(f => f.ID == chapterModel.FanficId).First();
            //fanfic.Chapters.Add(chapterModel);
            
            return RedirectToAction("EditFanfic", new { id = chapterModel.FanficId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(Comment commentModel)
        {
            Console.WriteLine("новый коммент fanficId=" + commentModel.FanficId);
            try
            {
                var user = await _userManager.GetUserAsync(User);
                commentModel.UserId = user.Id;
                commentModel.UserName = user.UserName;
                _db.Comments.Add(commentModel);
                //Fanfic fanfic =_db.Fanfics.Where(f => f.ID == chapterModel.FanficId).First();
                //fanfic.Chapters.Add(chapterModel);
                await _db.SaveChangesAsync();
                return RedirectToAction("ReadFic", "Fanfiction", new { id = commentModel.FanficId });
            }
            catch
            {
                return NotFound();
            }
        }
        private bool TransactionModelExists(object transactionId)
        {
            throw new NotImplementedException();
        }

         
        public async Task<IActionResult> DeleteChapter(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var chapterModel = await _db.Chapters
                .FirstOrDefaultAsync(m => m.ID == Id);
            if (chapterModel == null)
            {
                return NotFound();
            }
            _db.Chapters.Remove(chapterModel);
            await _db.SaveChangesAsync();
            return RedirectToAction("EditFanfic", new { id = chapterModel.FanficId });


        }

        public async Task<IActionResult> DeleteFanfic(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var fanficModel = await _db.Fanfics
                .FirstOrDefaultAsync(m => m.ID == Id);
            var bookmarks = _db.Bookmarks.Where(b => b.FanficId == Id).ToList();
            foreach(var b in bookmarks)
            {
                _db.Bookmarks.Remove(b);
            }

            var likes = _db.Likes.Where(b => b.FanficId == Id).ToList();
            foreach (var l in likes)
            {
                _db.Likes.Remove(l);
            } 
            

            if (fanficModel == null)
            {
                return NotFound();
            }
            
            _db.Fanfics.Remove(fanficModel);
            await _db.SaveChangesAsync();
            return RedirectToAction("MyProfile", "Fanfiction", new { id = fanficModel.AuthorId });


        }

        //[HttpPost]
        //public async Task<IActionResult> AddChapter(Chapter chapter)
        //{
        //    _db.Chapters.Add(chapter);
        //    //await _db.SaveChangesAsync();
        //    return PartialView("EditCanfic", chapter.Fanfic);
        //}

        //сделать 2 таких функции для категории и для фандома


        //public ActionResult AutocompleteSearch(string term)
        //{
        //    var a_suppliers = db.Ue_suppliers
        //        .Where(a => a.ShortName.Contains(term))
        //        .Select(a => a.ShortName);

        //    a_suppliers = a_suppliers.Union(
        //        db.Ue_suppliers
        //            .Where(a => a.Manager.Contains(term))
        //            .Select(a => a.Manager));

        //    a_suppliers = a_suppliers.Union(
        //        db.Ue_suppliers
        //            .Where(a => a.Name.Contains(term))
        //            .Select(a => a.Name));

        //    a_suppliers = a_suppliers.Union(
        //        db.Ue_suppliers
        //            .Where(a => a.PhoneManager.Contains(term))
        //            .Select(a => a.PhoneManager));

        //    a_suppliers = a_suppliers.Union(
        //        db.Ue_suppliers
        //            .Where(a => a.Phone.Contains(term))
        //            .Select(a => a.Phone));

        //    return Json(a_suppliers.ToArray(), JsonRequestBehavior.AllowGet);
        //}


        //создание лайка


    }
}
