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
                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    ICollection<Fanfic> fanficList = _db.Fanfics.Where(c => c.AuthorId == id).ToList();
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

            try
            {
                ICollection<Fanfic> fanficList = _db.Fanfics.Where(c => c.AuthorId == currentUser.Id).ToList();
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
                    var f = _db.Fanfics.Where(f => f.ID == b.FanficId).First();
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
                Console.WriteLine(fanficModel.Title);
                if(fanficModel == null)
                {
                    return NotFound();
                }
                else
                {
                    ICollection<Chapter> chapterList = _db.Chapters.Where(c => c.FanficId == Id).ToList();
                    fanficModel.Chapters = chapterList;
                    fanficModel.isLiked = false;
                    var comments = _db.Comments.Where(c => c.FanficId == Id).ToList();
                    var user = await _userManager.GetUserAsync(User);
                    var author = await _userManager.FindByIdAsync(fanficModel.AuthorId);
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
                    var bookmarks = _db.Bookmarks.Where(l => l.FanficId == Id).ToList();
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
                    ICollection<Fanfic> fanficList = _db.Fanfics.Where(c => c.FandomName == Convert.ToString(fandomModel.ID)).ToList();
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
