using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cours1test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cours1test.Controllers
{
    public class FanfictionController: Controller
    {

        private readonly FanficContextDB _db;
        private readonly UserContext _userDb;

        private readonly UserManager<User> _userManager;

        public FanfictionController(FanficContextDB context, UserContext userContext, UserManager<User> userManager)
        {
            _db = context;
            _userDb = userContext;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Authors(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var author = await _userManager.FindByIdAsync(id);
                ICollection<Authorship> authorships = _db.authorship.Where(a => a.UsreId == id).ToList();

                ICollection<Fanfic> _fanficList = Array.Empty<Fanfic>();
                var fanficList = _fanficList.ToList();

                foreach (Authorship linq in authorships)
                {
                    Fanfic newC = _db.Fanfics.Where(c => c.ID == linq.FanficID).First();
                    fanficList.Add(newC);
                }
                if (author == null)
                {
                    return NotFound();
                } 
                else
                {
                    author.Fanfics = fanficList; 
                    foreach (var f in author.Fanfics)
                    {
                        f.Likes = GetLikes(f);
                        f.Comments = GetComments(f);
                    }


                    return View(author);
                }

            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyProfile(string? userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            Console.WriteLine("My prof ID" + currentUser.Id);

            try
            {
                ICollection<Authorship> authorships = _db.authorship.Where(a => a.UsreId == currentUser.Id).ToList();

                ICollection<Fanfic> _fanficList = Array.Empty<Fanfic>();
                var fanficList = _fanficList.ToList();

                foreach (Authorship linq in authorships)
                {
                    Fanfic newC = _db.Fanfics.Where(c => c.ID == linq.FanficID).First();
                    fanficList.Add(newC);
                } 


                currentUser.Fanfics = fanficList;
                foreach(var f in currentUser.Fanfics)
                {
                    //var comments = _db.Comments.Where(c => c.FanficId == f.ID).ToList();
                    //f.Comments = comments;
                    f.Comments = GetComments(f);
                    //var likes =_db.Likes.Where(l => l.FanficId == f.ID).ToList();
                    //f.Likes = likes;
                    f.Likes = GetLikes(f);
                    Console.WriteLine("Вот сколько лайков у fanficId= "+ f.ID +" likes = " + f.Likes.Count());
                }
                Console.WriteLine("успешное присовение фанфиков хых количеством: "+ currentUser.Fanfics.Count());
            }
            catch
            {
                Console.WriteLine("НЕ успешное присовение фанфиков хых");
            }
            if (userId != null)
            { 
                
                if (currentUser.Id == userId)
                {
                    return View(currentUser);
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return View(currentUser);
            }

            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyBookmarks()
        {
            var user = await _userManager.GetUserAsync(User);
            ICollection<Bookmark> bookmarks = _db.Bookmarks.Where(b => b.UserId == user.Id).ToList();

            //ICollection<Fanfic> fanfics = null;
            foreach (var b in bookmarks)
            {
                try
                {
                    var f = _db.Fanfics.Where(f => f.ID == b.FanficID).First();
                    b.Fanfic = f;
                    b.Fanfic.Comments = GetComments(b.Fanfic);
                    b.Fanfic.Likes = GetLikes(b.Fanfic);
                }
                catch
                {
                    Console.Write("нет у данного фф чегото");
                }
            }


            return View(bookmarks);

        }

        [HttpGet]
        public async Task<IActionResult> Readfic(int? Id)
        {
            if (Id == null)
            {

                return NotFound();

            }
            else
            {
                Fanfic fanficModel = new Fanfic();
                fanficModel = _db.Fanfics.Where(f => f.ID == Id).First();
                
                if(fanficModel == null)
                {
                    return NotFound();
                }
                else
                {
                    ICollection<BookChapter> bChapList = _db.bookChapter.Where(c => c.Fanfic.ID == fanficModel.ID).ToList();
                    Console.WriteLine("кол-во глав" + bChapList.Count());
                    ICollection<Chapter> _chapterList = Array.Empty<Chapter>();
                    var chapterList = _chapterList.ToList();

                    foreach (BookChapter linq in bChapList) {
                        Chapter newC = _db.Chapters.Where(c => c.ID == linq.ChapterId).First();
                        chapterList.Add(newC);
                    }

                    try
                    {
                        fanficModel.Chapters = chapterList.OrderBy(s => s.RangeId).ToList();
                    } catch { Console.WriteLine("fail find Book - Chapter"); }
                    
                    fanficModel.isLiked = false;
                    var comments = _db.Comments.Where(c => c.FanficId == Id).ToList();
                    var user = await _userManager.GetUserAsync(User);
                    var bookFandom = _db.bookFandom.FirstOrDefault(f => f.FanficID == fanficModel.ID);
                    var fandom = _db.Fandom.Where(f => f.ID == bookFandom.FandomId);


                    var boookAuthor =  _db.authorship.FirstOrDefault(a => a.FanficID == fanficModel.ID);
                    var author = await _userManager.FindByIdAsync(boookAuthor.UsreId);
                    fanficModel.Author = author;
                    fanficModel.inBookmarks = false;
                    if (comments.Count() != 0)
                    {
                        fanficModel.Comments = comments;
                    }

                    var likes = _db.Likes.Where(l => l.FanficId == Id).ToList();
                    if(likes.Count() != 0)
                    {
                        fanficModel.Likes = likes;
                        
                    }

                    try
                    { 
                        if (likes.Where(l => l.UserId == user.Id).Count() >= 1)
                        {
                            fanficModel.isLiked = true;
                        }
                    }
                    catch
                    {
                        fanficModel.isLiked = false;
                    }

                    var bookmarks = _db.Bookmarks.Where(l => l.FanficID == Id).ToList();
                    if (likes.Count() != 0)
                    {
                        fanficModel.Bookmarks = bookmarks;

                    }


                    try
                    { 
                        if (bookmarks.Where(l => l.UserId == user.Id).Count() >= 1)
                        {
                            fanficModel.inBookmarks = true;
                        }
                    }
                    catch
                    {
                        fanficModel.inBookmarks = false;
                    }

                    Console.WriteLine("Title " + fanficModel.Title);
                    Console.WriteLine("ID " + fanficModel.ID);
                    Console.WriteLine("chapter " + fanficModel.Chapters);
                    Console.WriteLine("Description " + fanficModel.Description);
                    Console.WriteLine("Fandom " + fanficModel.Fandom);

                    return View(fanficModel);
                }
                
            }


            
        }

        [HttpGet]
        public  IActionResult Books(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            else
            {
                var fandomModel = _db.Fandom.Where(f => f.ID == Id).First();
                if (fandomModel == null)
                {
                    return NotFound();
                }
                else
                {
                    ICollection<BookFandom> bookFandom = _db.bookFandom.Where(a => a.FandomId == Id).ToList();

                    ICollection<Fanfic> _fanficList = Array.Empty<Fanfic>();
                    var fanficList = _fanficList.ToList();

                    foreach (BookFandom linq in bookFandom)
                    {
                        Fanfic newC = _db.Fanfics.Where(c => c.ID == linq.FanficID).First();
                        fanficList.Add(newC);
                    }
                    fandomModel.Fanfics = fanficList; 
                    foreach (var f in fandomModel.Fanfics)
                    {
                        f.Likes = GetLikes(f);
                        f.Comments = GetComments(f);
                    }


                    return View(fandomModel);
                }

            }
        }

        public ICollection<PostLike> GetLikes(Fanfic f)
        {
            var likes = _db.Likes.Where(l => l.FanficId == f.ID).ToList(); ;

            return likes;
        }

        public ICollection<Comment> GetComments(Fanfic f)
        {
            var comments = _db.Comments.Where(l => l.FanficId == f.ID).ToList(); ;

            return comments;
        }

        

    }
}
