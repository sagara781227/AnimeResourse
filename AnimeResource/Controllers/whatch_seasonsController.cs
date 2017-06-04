using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimeResource.Models;

namespace AnimeResource.Controllers
{
    public class whatch_seasonsController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: whatch_seasons
        public ActionResult Index()
        {
            var whatch_seasons = db.whatch_seasons.Include(w => w.serii).Include(w => w.users_anime);
            return View(whatch_seasons.ToList());
        }

        // GET: whatch_seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            whatch_seasons whatch_seasons = db.whatch_seasons.Find(id);
            if (whatch_seasons == null)
            {
                return HttpNotFound();
            }
            return View(whatch_seasons);
        }

        // GET: whatch_seasons/Create
        public ActionResult Create()
        {
            ViewBag.id_serii = new SelectList(db.seriis, "id_serii", "link");
            ViewBag.id_user = new SelectList(db.users_anime, "id_user", "id_user");
            return View();
        }

        // POST: whatch_seasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ws,wotch,id_user,id_anime,id_serii")] whatch_seasons whatch_seasons)
        {
            if (ModelState.IsValid)
            {
                db.whatch_seasons.Add(whatch_seasons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_serii = new SelectList(db.seriis, "id_serii", "link", whatch_seasons.id_serii);
            ViewBag.id_user = new SelectList(db.users_anime, "id_user", "id_user", whatch_seasons.id_user);
            return View(whatch_seasons);
        }

        // GET: whatch_seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            whatch_seasons whatch_seasons = db.whatch_seasons.Find(id);
            if (whatch_seasons == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_serii = new SelectList(db.seriis, "id_serii", "link", whatch_seasons.id_serii);
            ViewBag.id_user = new SelectList(db.users_anime, "id_user", "id_user", whatch_seasons.id_user);
            return View(whatch_seasons);
        }

        // POST: whatch_seasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ws,wotch,id_user,id_anime,id_serii")] whatch_seasons whatch_seasons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whatch_seasons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_serii = new SelectList(db.seriis, "id_serii", "link", whatch_seasons.id_serii);
            ViewBag.id_user = new SelectList(db.users_anime, "id_user", "id_user", whatch_seasons.id_user);
            return View(whatch_seasons);
        }

        // GET: whatch_seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            whatch_seasons whatch_seasons = db.whatch_seasons.Find(id);
            if (whatch_seasons == null)
            {
                return HttpNotFound();
            }
            return View(whatch_seasons);
        }

        // POST: whatch_seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            whatch_seasons whatch_seasons = db.whatch_seasons.Find(id);
            db.whatch_seasons.Remove(whatch_seasons);
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
