using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StriderCupRacing.Models;

namespace StriderCupRacing.Controllers
{   
    public class RacesController : Controller
    {
        private StriderCupRacingContext context = new StriderCupRacingContext();

        //
        // GET: /Races/

        public ViewResult Index()
        {
            return View(context.Races.ToList());
        }

        //
        // GET: /Races/Details/5

        public ViewResult Details(int id)
        {
            Race race = context.Races.Single(x => x.RaceId == id);
            return View(race);
        }

        //
        // GET: /Races/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Races/Create

        [HttpPost]
        public ActionResult Create(Race race)
        {
            if (ModelState.IsValid)
            {
                context.Races.Add(race);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(race);
        }
        
        //
        // GET: /Races/Edit/5
 
        public ActionResult Edit(int id)
        {
            Race race = context.Races.Single(x => x.RaceId == id);
            return View(race);
        }

        //
        // POST: /Races/Edit/5

        [HttpPost]
        public ActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
                context.Entry(race).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(race);
        }

        //
        // GET: /Races/Delete/5
 
        public ActionResult Delete(int id)
        {
            Race race = context.Races.Single(x => x.RaceId == id);
            return View(race);
        }

        //
        // POST: /Races/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = context.Races.Single(x => x.RaceId == id);
            context.Races.Remove(race);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}