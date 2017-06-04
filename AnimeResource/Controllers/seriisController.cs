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
    public class seriisController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: seriis
        public ActionResult Index()
        {
            var seriis = db.seriis.Include(s => s.anime).Include(s => s.typeser);
            return View(seriis.ToList());
        }

        // GET: seriis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            serii serii = db.seriis.Find(id);
            if (serii == null)
            {
                return HttpNotFound();
            }
            return View(serii);
        }

        // GET: seriis/Create
        public ActionResult Create()
        {
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim");
            ViewBag.id_typeser = new SelectList(db.typesers, "id_typeser", "name");
            return View();
        }

        // POST: seriis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_serii,id_anime,link,id_typeser")] serii serii)
        {
            if (ModelState.IsValid)
            {
                db.seriis.Add(serii);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", serii.id_anime);
            ViewBag.id_typeser = new SelectList(db.typesers, "id_typeser", "name", serii.id_typeser);
            return View(serii);
        }

        // GET: seriis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            serii serii = db.seriis.Find(id);
            if (serii == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", serii.id_anime);
            ViewBag.id_typeser = new SelectList(db.typesers, "id_typeser", "name", serii.id_typeser);
            return View(serii);
        }

        // POST: seriis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_serii,id_anime,link,id_typeser")] serii serii)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serii).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", serii.id_anime);
            ViewBag.id_typeser = new SelectList(db.typesers, "id_typeser", "name", serii.id_typeser);
            return View(serii);
        }

        // GET: seriis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            serii serii = db.seriis.Find(id);
            if (serii == null)
            {
                return HttpNotFound();
            }
            return View(serii);
        }

        // POST: seriis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            serii serii = db.seriis.Find(id);
            db.seriis.Remove(serii);
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
