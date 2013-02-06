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
    public class TeamsController : Controller
    {
        private StriderCupRacingContext context = new StriderCupRacingContext();

        //
        // GET: /Teams/

        public ViewResult Index()
        {
            return View(context.Teams.ToList());
        }

        //
        // GET: /Teams/Details/5

        public ViewResult Details(int id)
        {
            Team team = context.Teams.Single(x => x.TeamId == id);
            return View(team);
        }

        //
        // GET: /Teams/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Teams/Create

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                context.Teams.Add(team);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(team);
        }
        
        //
        // GET: /Teams/Edit/5
 
        public ActionResult Edit(int id)
        {
            Team team = context.Teams.Single(x => x.TeamId == id);
            return View(team);
        }

        //
        // POST: /Teams/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                context.Entry(team).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        //
        // GET: /Teams/Delete/5
 
        public ActionResult Delete(int id)
        {
            Team team = context.Teams.Single(x => x.TeamId == id);
            return View(team);
        }

        //
        // POST: /Teams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = context.Teams.Single(x => x.TeamId == id);
            context.Teams.Remove(team);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}