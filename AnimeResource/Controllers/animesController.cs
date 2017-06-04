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
    public class animesController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: animes
        public ActionResult Index()
        {
            var animes = db.animes.Include(a => a.sound);
            return View(animes.ToList());
        }

        // GET: animes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anime anime = db.animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // GET: animes/Create
        public ActionResult Create()
        {
            ViewBag.id_sound = new SelectList(db.sounds, "id_sound", "name");
            return View();
        }

        // POST: animes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_anime,nameanim,about,year,kolser,kolova,kolmov,kolsp,id_sound,image,link")] anime anime)
        {
            if (ModelState.IsValid)
            {
                db.animes.Add(anime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_sound = new SelectList(db.sounds, "id_sound", "name", anime.id_sound);
            return View(anime);
        }

        // GET: animes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anime anime = db.animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sound = new SelectList(db.sounds, "id_sound", "name", anime.id_sound);
            return View(anime);
        }

        // POST: animes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_anime,nameanim,about,year,kolser,kolova,kolmov,kolsp,id_sound,image,link")] anime anime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sound = new SelectList(db.sounds, "id_sound", "name", anime.id_sound);
            return View(anime);
        }

        // GET: animes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anime anime = db.animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // POST: animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anime anime = db.animes.Find(id);
            db.animes.Remove(anime);
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
