using System;
using System.IO;
using System.Threading.Tasks;
using cours1test.Models;
using cours1test.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims; 
using System.Text.Json;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static cours1test.Helper; 


namespace cours1test.Controllers

{
    public class FanficController : Controller
    {

        private readonly FanficContextDB _db;
        private readonly UserContext _userDb;
        private readonly UserManager<User> _userManager;
        Random rng = new Random();


        private static int NextIntId()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            int result = BitConverter.ToInt32(buffer, 0);

            return new Random(result).Next();
        }

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
            Console.WriteLine("попытка найти фанфик для эдитп" + Id);
            Fanfic fanfic = _db.Fanfics.Where(f => f.ID == Id).First(); 

            ICollection<BookChapter> bChapList = _db.bookChapter.Where(c => c.Fanfic == fanfic).ToList();
            ICollection<Chapter> chapters = Array.Empty<Chapter>();
            var _chapters = chapters.ToList();

            Console.WriteLine("Сколько чаптер листов" + bChapList.Count());

            var _bChapList = bChapList.ToList();
            foreach (var linq in _bChapList)
            {
                Chapter newC = _db.Chapters.Where(c => c.ID == linq.ChapterId).First();
                Console.WriteLine("newC . ID" + newC.ID);
                _chapters.Add(newC);
            }

            try
            {
                fanfic.Chapters = _chapters.OrderBy(s => s.RangeId).ToList();
            } catch
            {
                fanfic.Chapters = null;
            }

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
                BookFandom fandom = new BookFandom();
                fandom.FandomId = fanficModel.Fandom.ID;
                fandom.FanficID = fanfic.ID; 
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
          

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {

            return View();
        }

         

        [HttpPost]
        public async Task<IActionResult> Create(Fanfic model)
        {



            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine("Из вью id и name" + model.Fandom + " , " + model.FandomName);
            Authorship authorship = new Authorship();
            BookFandom bookFandom = new BookFandom();
            model.ID = NextIntId();
            _db.Fanfics.Add(model);
            await _db.SaveChangesAsync();


           

            authorship.AuthorshipID = NextIntId();
            authorship.UsreId = user.Id;
            authorship.FanficID = model.ID;
            _db.authorship.Add(authorship);
            await _db.SaveChangesAsync(); 
            bookFandom.idf = NextIntId();
            bookFandom.FandomId = Convert.ToInt32(model.FandomName);
            bookFandom.FanficID = model.ID;
            _db.bookFandom.Add(bookFandom);
            

            await _db.SaveChangesAsync();  
            return RedirectToAction("EditFanfic", new {  id = model.ID });
             
        }

        [HttpGet]
        public IActionResult AddChapter(int Id)
        {


            Chapter chapterModel = new Chapter();
            BookChapter bookChapter = new BookChapter();
            bookChapter.Fanfic = _db.Fanfics.Where(f => f.ID == Id).Last();

            return PartialView("AddChapter", chapterModel);
        }

        [HttpGet]
        public async Task<IActionResult> ClickLike(int fanficId)
        {
            var user = await _userManager.GetUserAsync(User); 
            PostLike like = new PostLike(); 
            like.UserId = user.Id;
            like.FanficId = fanficId;  
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
            bookmark.FanficID = fanficId;  
            _db.Bookmarks.Add(bookmark);
            _db.SaveChanges();

            return RedirectToAction("ReadFic", "Fanfiction", new { id = fanficId });

        }
        
        [HttpGet]
        public async Task<IActionResult> RemoveBookmark(int fanficId)
        {

            var user = await _userManager.GetUserAsync(User);
            Bookmark bookmark = new Bookmark();
            bookmark = _db.Bookmarks.Where(l => l.UserId == user.Id && l.FanficID == fanficId).First();
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
                Console.WriteLine("где id == 0");

                Chapter chapterModel = new Chapter();
                BookChapter bookChapter = new BookChapter();
                Fanfic fanfic = _db.Fanfics.First(f => f.ID == fanficId); 
                bookChapter.FanficID = fanfic.ID; 
                chapterModel.ID = NextIntId();
                bookChapter.idc = NextIntId();
                bookChapter.ChapterId = chapterModel.ID;
                chapterModel.bookChapterId = bookChapter.idc;
                _db.bookChapter.Add(bookChapter);

                

                await _db.SaveChangesAsync();
                chapterModel.FanficID = bookChapter.FanficID;


                chapterModel.RangeId = _db.bookChapter.Where(c => c.Fanfic == fanfic).Count();
                Console.WriteLine("пытаюсь вызвать попап где bookChapterId RangeId  = " + chapterModel.bookChapterId);
                return View(chapterModel);
            } 
            else
            { 
                Console.WriteLine("новый fanficId=" + fanficId);
                var chapterModel = await _db.Chapters.FindAsync(id);
                if (chapterModel == null)
                {
                    return NotFound();
                }
                BookChapter bookChapter = await _db.bookChapter.FindAsync(id);
                chapterModel.FanficID = fanficId; 
                return View(chapterModel);
            }
        }

         

        [HttpPost]
        public async Task<IActionResult> AddOrEditChapter(Chapter chapterModel)
        {
            int fanficId = chapterModel.FanficID; 
            try
                {
                    var chapter = _db.Chapters.First(c => c.ID == chapterModel.ID);
                    chapter.CText = chapterModel.CText;
                    chapter.CName = chapterModel.CName;
                    chapter.RangeId = chapterModel.RangeId;

                    _db.SaveChanges(); 
                
                }
            catch
                { 
                //Console.WriteLine("Сохранила новую главу со связью? " + chapterModel.bookChapterId); 
                _db.Chapters.Add(chapterModel);
                await _db.SaveChangesAsync();

                BookChapter bookChapter2 = _db.bookChapter.First(b => b.idc == chapterModel.bookChapterId);
                bookChapter2.ChapterId = chapterModel.ID;
                fanficId = bookChapter2.FanficID;
                _db.SaveChanges();
            }

            //BookChapter bookChapter = _db.bookChapter.Where(c => c.ChapterId == chapterModel.ID).Last();
            
            return RedirectToAction("EditFanfic", new { id = fanficId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(Comment commentModel)
        { 
            try
            {
                var user = await _userManager.GetUserAsync(User);
                commentModel.UserId = user.Id;
                commentModel.UserName = user.UserName;
                _db.Comments.Add(commentModel);
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
            BookChapter bc =  _db.bookChapter.Where(m => m.ChapterId == Id).First() ;
            int fID = bc.FanficID; 
            //_db.Chapters.Remove(chapterModel);
            _db.bookChapter.Remove(bc);
            await _db.SaveChangesAsync();
            return RedirectToAction("EditFanfic", new { id = fID });


        }

        public async Task<IActionResult> DeleteFanfic(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var fanficModel = await _db.Fanfics
                .FirstOrDefaultAsync(m => m.ID == Id);
            var bookmarks = _db.Bookmarks.Where(b => b.FanficID == Id).ToList();
            foreach(var b in bookmarks)
            {
                _db.Bookmarks.Remove(b);
            }

            var authorship = _db.authorship.Where(b => b.FanficID == Id).ToList();
            foreach (var b in authorship)
            {
                _db.authorship.Remove(b);
            }
            await _db.SaveChangesAsync();

            var bookchapter = _db.bookChapter.Where(b => b.FanficID == Id).ToList();
            foreach (var b in bookchapter)
            {
                _db.bookChapter.Remove(b);
            }
            await _db.SaveChangesAsync();

            var bookfandom = _db.bookFandom.Where(b => b.FanficID == Id).ToList();
            foreach (var b in bookfandom)
            {
                _db.bookFandom.Remove(b);
            }
            await _db.SaveChangesAsync();

            var likes = _db.Likes.Where(b => b.FanficId == Id).ToList();
            foreach (var l in likes)
            {
                _db.Likes.Remove(l);
            }
            await _db.SaveChangesAsync();

            if (fanficModel == null)
            {
                return NotFound();
            }
            
            _db.Fanfics.Remove(fanficModel);
            await _db.SaveChangesAsync();
            return RedirectToAction("MyProfile", "Fanfiction", new { id = fanficModel.AuthorId });


        } 
    }
}
