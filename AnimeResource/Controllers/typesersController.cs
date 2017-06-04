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
    public class typesersController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: typesers
        public ActionResult Index()
        {
            return View(db.typesers.ToList());
        }

        // GET: typesers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeser typeser = db.typesers.Find(id);
            if (typeser == null)
            {
                return HttpNotFound();
            }
            return View(typeser);
        }

        // GET: typesers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: typesers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_typeser,name")] typeser typeser)
        {
            if (ModelState.IsValid)
            {
                db.typesers.Add(typeser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeser);
        }

        // GET: typesers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeser typeser = db.typesers.Find(id);
            if (typeser == null)
            {
                return HttpNotFound();
            }
            return View(typeser);
        }

        // POST: typesers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_typeser,name")] typeser typeser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeser);
        }

        // GET: typesers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeser typeser = db.typesers.Find(id);
            if (typeser == null)
            {
                return HttpNotFound();
            }
            return View(typeser);
        }

        // POST: typesers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typeser typeser = db.typesers.Find(id);
            db.typesers.Remove(typeser);
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
