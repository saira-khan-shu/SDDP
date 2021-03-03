using System.Linq;
using System.Web.Mvc;
using BuilderingApp.Models;
using System.Data.Entity;
using System.Net;
using System.Collections.Generic;

namespace BuilderingApp.Controllers
{
    public class RouteController : Controller
    {
        private RouteDBContext db = new RouteDBContext();

        public ActionResult Index (string Grade1, string searchString)
        {
            var GradeLst = new List<string>();

            var GradeQry = from r in db.Routes
                           orderby r.Grade
                           select r.Grade;
            GradeLst.AddRange(GradeQry.Distinct());
            ViewBag.Grade1 = new SelectList(GradeLst);

            var routes = from t in db.Routes
                         select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                routes = routes.Where(s => s.Description.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(Grade1))
            {
                routes = routes.Where(x => x.Grade == Grade1);
            }
            return View(routes);

        } 

        //// GET: Route
        //public ActionResult Index()
        //{
        //    return View(db.Routes.ToList());
        //}

        // GET: Route/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = 
            "ID,Coordinate,Description,Topo,Rating,Grade,Photo,Comments,User,Video")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(route);
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Route/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
                        "ID,Coordinate,Description,Topo,Rating,Grade,Photo,Comments,User,Video")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(route);
            
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int? id)
        {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Route route= db.Routes.Find(id);
        if (route == null)
        {
            return HttpNotFound();
        }
        return View(route);
        }

    // POST: Route/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Route route = db.Routes.Find(id);
        db.Routes.Remove(route);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
}
