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


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var model = new AddFanficModel();
            //var fandomList = _db.Fandoms.ToList();
            //ViewBag.FandomList = new SelectList(_db.Fandom, "ID", "Titile", "Author");

            var FandomList = new SelectList(_db.Fandom.ToList(), "ID", "Titile"); 
            ViewData["DBMyfandom"] = FandomList;
            //dynamic mymodel = new ExpandoObject();
            //mymodel.Fanfic = GetFanfic();
            //mymodel.Chapters = GetChapters();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditFanfic(int Id)
        {
            Console.WriteLine("new id request " + Id);
            //var fanfic = new Fanfic();
            //Chapter c = _db.Chapters.Where(c => c.ID == Id).Last();
            Fanfic fanfic = _db.Fanfics.Where(f => f.ID == Id).First();
            //ViewBag.FandomList = new SelectList(_db.Fandoms, "ID", "Titile");
            var FandomList = new SelectList(_db.Fandom.ToList(), "ID", "Titile");
            ICollection<Chapter> chapterList = _db.Chapters.Where(c => c.FanficId == Id).ToList();
            fanfic.Chapters = chapterList;

            ViewData["DBMyfandoms"] = FandomList;

            return View(fanfic);
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
            //var userId = user.Id;
            try
            {


                model.AuthorId = user.Id;
            }
            catch
            {
                Console.WriteLine("fsdfdsfdsf");
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

        //[NoDirectAccess]
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditChapter(int fanficId,int id = 0 )
        {
            
            if (id == 0)
            {
                Console.WriteLine("вызвался метод с id=0");
                Console.WriteLine("новый fanficId="+ fanficId);
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

        //[HttpGet]
        //public async Task<IActionResult> AddOrEditChapter(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = await _db.Chapters.FindAsync(Id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddOrEditChapter(int? Id, Chapter chapterModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Console.WriteLine("ModelState.IsValid = true");
        //        //Insert
        //        if (Id == 0)
        //        {
        //            Console.WriteLine("Попытался сохранить в базу при id == 0");
        //            _db.Add(chapterModel);
        //            await _db.SaveChangesAsync();

        //        }
        //        //Update
        //        else
        //        {
        //            Console.WriteLine("Попытался сохранить в базу при id != 0");
        //            try
        //            {

        //                _db.Update(chapterModel);
        //                await _db.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                Console.WriteLine("сработал какой то кэтч сука");
        //                if (!TransactionModelExists(chapterModel.ID))
        //                { return NotFound(); }
        //                else
        //                { throw; }
        //            }
        //        }
        //        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _db.Chapters.ToList()) });
        //    } 

        //    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditChapter", chapterModel) });
        //}

        [HttpPost]
        public async Task<IActionResult> AddOrEditChapter(Chapter chapterModel)
        {
            Console.WriteLine("Попытался сохранить в базу при id == 0");

            Console.WriteLine("Должен сохранить FanficId из модели = "+ chapterModel.FanficId);

            _db.Chapters.Add(chapterModel);
            //Fanfic fanfic =_db.Fanfics.Where(f => f.ID == chapterModel.FanficId).First();
            //fanfic.Chapters.Add(chapterModel);
            await _db.SaveChangesAsync(); 
            return RedirectToAction("EditFanfic", new { id = chapterModel.FanficId });
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
