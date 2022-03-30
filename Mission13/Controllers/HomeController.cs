using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using Mission13.Models.ViewModels;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository repo { get; set; }

        //Constructor 
        public HomeController(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string teamname)
        {
            var x = repo.Bowlers
            .Where(x => x.Team.TeamName == teamname || teamname == null);
           

            return View(repo.Bowlers.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            repo.SaveBowler(b);
            return View("Index", repo.Bowlers.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int BowlerID)
        {
            var b = repo.Bowlers.Single(i => i.BowlerID == BowlerID);

            return View("Add", b);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            repo.UpdateBowler(b);

            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var b = repo.Bowlers.Single(i => i.BowlerID == bowlerid);

            return View(b);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            repo.DeleteBowler(b);
            return RedirectToAction("Index", repo.Bowlers.ToList());
        }
    }
}
