using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cours1test.Models;

namespace cours1test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FanficContextDB _db; 

         

        public HomeController(FanficContextDB context, ILogger<HomeController> logger)
        {
            _db = context;
            _logger = logger;
        }

        public IActionResult Index(string? sortOrder)
        {
            //ICollection<Fanfic> fanfics = _db.Fanfics.ToList();

            var fanfics = _db.Fanfics.ToList();
            foreach( var f in fanfics)
            {
                f.Likes = GetLikes(f);
                f.Comments = GetComments(f);
            }
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ActiveSortParm = sortOrder == "likes" ? "comments" : "likes";

            switch (sortOrder)
            {
                case "name_desc":
                    fanfics = fanfics.OrderByDescending(s => s.Title).ToList();
                    break;
                case "likes":
                    fanfics = fanfics.OrderByDescending(s => s.Likes.Count()).ToList();
                    break;
                case "comments":
                    fanfics = fanfics.OrderByDescending(s => s.Comments.Count()).ToList();
                    break;
                default:
                    fanfics = fanfics.OrderBy(s => s.Title).ToList();
                    break;
            }

            //return Content(User.Identity.Name); 
            return View(fanfics);
        }

        public IActionResult SearchPage(string searching)
        {
            //ICollection<Fanfic> fanfics = _db.Fanfics.ToList();
            Console.WriteLine("Часть поиска: "+ searching);
            var fanfics = _db.Fanfics.Where(
                f => f.Title.Contains(searching) ||
                f.Description.Contains(searching) ||
                f.Fandom.Titile.Contains(searching)).ToList();

            foreach (var f in fanfics)
            {
                f.Likes = GetLikes(f);
                f.Comments = GetComments(f);
            }

            //return Content(User.Identity.Name); 
            return View(fanfics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
