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
    public class marksController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: marks
        public ActionResult Index()
        {
            var marks = db.marks.Include(m => m.anime).Include(m => m.user);
            return View(marks.ToList());
        }

        // GET: marks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: marks/Create
        public ActionResult Create()
        {
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim");
            ViewBag.id_user = new SelectList(db.users, "id_user", "login");
            return View();
        }

        // POST: marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mark,id_user,id_anime,mark1")] mark mark)
        {
            if (ModelState.IsValid)
            {
                db.marks.Add(mark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", mark.id_anime);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", mark.id_user);
            return View(mark);
        }

        // GET: marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", mark.id_anime);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", mark.id_user);
            return View(mark);
        }

        // POST: marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mark,id_user,id_anime,mark1")] mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_anime = new SelectList(db.animes, "id_anime", "nameanim", mark.id_anime);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", mark.id_user);
            return View(mark);
        }

        // GET: marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mark mark = db.marks.Find(id);
            db.marks.Remove(mark);
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
