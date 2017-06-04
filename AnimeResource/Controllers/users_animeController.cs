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
    public class users_animeController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: users_anime
        public ActionResult Index()
        {
            var users_anime = db.users_anime.Include(u => u.anime).Include(u => u.user);
            return View(users_anime.ToList());
        }

        // GET: users_anime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_anime users_anime = db.users_anime.Find(id);
            if (users_anime == null)
            {
                return HttpNotFound();
            }
            return View(users_anime);
        }

        // GET: users_anime/Create
        public ActionResult Create()
        {
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim");
            ViewBag.id_user = new SelectList(db.users, "id_user", "login");
            return View();
        }

        // POST: users_anime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_user,id_anime")] users_anime users_anime)
        {
            if (ModelState.IsValid)
            {
                db.users_anime.Add(users_anime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", users_anime.id_anime);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", users_anime.id_user);
            return View(users_anime);
        }

        // GET: users_anime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_anime users_anime = db.users_anime.Find(id);
            if (users_anime == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", users_anime.id_anime);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", users_anime.id_user);
            return View(users_anime);
        }

        // POST: users_anime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,id_anime")] users_anime users_anime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users_anime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", users_anime.id_anime);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", users_anime.id_user);
            return View(users_anime);
        }

        // GET: users_anime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_anime users_anime = db.users_anime.Find(id);
            if (users_anime == null)
            {
                return HttpNotFound();
            }
            return View(users_anime);
        }

        // POST: users_anime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users_anime users_anime = db.users_anime.Find(id);
            db.users_anime.Remove(users_anime);
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
