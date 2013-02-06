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
    public class TracksController : Controller
    {
        private StriderCupRacingContext context = new StriderCupRacingContext();

        //
        // GET: /Tracks/

        public ViewResult Index()
        {
            return View(context.Tracks.ToList());
        }

        //
        // GET: /Tracks/Details/5

        public ViewResult Details(int id)
        {
            Track track = context.Tracks.Single(x => x.TrackId == id);
            return View(track);
        }

        //
        // GET: /Tracks/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tracks/Create

        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                context.Tracks.Add(track);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(track);
        }
        
        //
        // GET: /Tracks/Edit/5
 
        public ActionResult Edit(int id)
        {
            Track track = context.Tracks.Single(x => x.TrackId == id);
            return View(track);
        }

        //
        // POST: /Tracks/Edit/5

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                context.Entry(track).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(track);
        }

        //
        // GET: /Tracks/Delete/5
 
        public ActionResult Delete(int id)
        {
            Track track = context.Tracks.Single(x => x.TrackId == id);
            return View(track);
        }

        //
        // POST: /Tracks/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = context.Tracks.Single(x => x.TrackId == id);
            context.Tracks.Remove(track);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}