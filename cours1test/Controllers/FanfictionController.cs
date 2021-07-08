using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cours1test.Models;
using Microsoft.AspNetCore.Mvc;

namespace cours1test.Controllers
{
    public class FanfictionController: Controller
    {

        private readonly FanficContextDB _db;
        private readonly UserContext _userDb; 


        public FanfictionController(FanficContextDB context, UserContext userContext)
        {
            _db = context;
            _userDb = userContext; 
        }

        [HttpGet]
        public IActionResult Authors(string id)
        {
            var fanfics = _db.Fanfics.Where(f => f.AuthorId == id);


            return View(fanfics);
        }

        [HttpGet]
        public async Task<IActionResult> Readfic(int Id)
        {
            if(Id == null)
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
                    return View(fanficModel);
                }
                
            }


            
        }

        [HttpGet]
        public async Task<IActionResult> Books(int Id)
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
                    ICollection<Fanfic> fanficList = _db.Fanfics.Where(c => c.Fandom == fandomModel).ToList();
                    fandomModel.Fanfics = fanficList;
                    return View(fandomModel);
                }

            }
        }

    }
}
