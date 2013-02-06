//
using System.Data;
using System.Linq;
using System.Web.Mvc;
//
using StriderCupRacing.Models;

namespace StriderCupRacing.Controllers
{   
    public class RidersController : Controller
    {
        private StriderCupRacingContext context = new StriderCupRacingContext();

        //
        // GET: /Riders/

        public ViewResult Index()
        {
            return View(context.Riders.ToList());
        }

        //
        // GET: /Riders/Details/5

        public ViewResult Details(int id)
        {
            Rider rider = context.Riders.Single(x => x.RiderId == id);
            return View(rider);
        }

        //
        // GET: /Riders/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Riders/Create

        [HttpPost]
        public ActionResult Create(Rider rider)
        {
            if (ModelState.IsValid)
            {
                context.Riders.Add(rider);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(rider);
        }
        
        //
        // GET: /Riders/Edit/5
 
        public ActionResult Edit(int id)
        {
            Rider rider = context.Riders.Single(x => x.RiderId == id);
            return View(rider);
        }

        //
        // POST: /Riders/Edit/5

        [HttpPost]
        public ActionResult Edit(Rider rider)
        {
            if (ModelState.IsValid)
            {
                context.Entry(rider).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rider);
        }

        //
        // GET: /Riders/Delete/5
 
        public ActionResult Delete(int id)
        {
            Rider rider = context.Riders.Single(x => x.RiderId == id);
            return View(rider);
        }

        //
        // POST: /Riders/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Rider rider = context.Riders.Single(x => x.RiderId == id);
            context.Riders.Remove(rider);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}