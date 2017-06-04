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
    public class profilesController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: profiles
        public ActionResult Index()
        {
            var profiles = db.profiles.Include(p => p.country).Include(p => p.sex).Include(p => p.user);
            return View(profiles.ToList());
        }

        // GET: profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: profiles/Create
        public ActionResult Create()
        {
            ViewBag.id_country = new SelectList(db.countries, "id_country", "name");
            ViewBag.id_sex = new SelectList(db.sexs, "id_sex", "name");
            ViewBag.id_user = new SelectList(db.users, "id_user", "login");
            return View();
        }

        // POST: profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_user,name,sername,birth,avatar,about,id_sex,id_country")] profile profile)
        {
            if (ModelState.IsValid)
            {
                db.profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_country = new SelectList(db.countries, "id_country", "name", profile.id_country);
            ViewBag.id_sex = new SelectList(db.sexs, "id_sex", "name", profile.id_sex);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", profile.id_user);
            return View(profile);
        }

        // GET: profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_country = new SelectList(db.countries, "id_country", "name", profile.id_country);
            ViewBag.id_sex = new SelectList(db.sexs, "id_sex", "name", profile.id_sex);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", profile.id_user);
            return View(profile);
        }

        // POST: profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,name,sername,birth,avatar,about,id_sex,id_country")] profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_country = new SelectList(db.countries, "id_country", "name", profile.id_country);
            ViewBag.id_sex = new SelectList(db.sexs, "id_sex", "name", profile.id_sex);
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", profile.id_user);
            return View(profile);
        }

        // GET: profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profile profile = db.profiles.Find(id);
            db.profiles.Remove(profile);
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
