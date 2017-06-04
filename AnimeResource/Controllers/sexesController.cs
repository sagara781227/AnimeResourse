﻿using System;
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
    public class sexesController : Controller
    {
        private AnimeContext db = new AnimeContext();

        // GET: sexes
        public ActionResult Index()
        {
            return View(db.sexs.ToList());
        }

        // GET: sexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sex sex = db.sexs.Find(id);
            if (sex == null)
            {
                return HttpNotFound();
            }
            return View(sex);
        }

        // GET: sexes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sex,name")] sex sex)
        {
            if (ModelState.IsValid)
            {
                db.sexs.Add(sex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sex);
        }

        // GET: sexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sex sex = db.sexs.Find(id);
            if (sex == null)
            {
                return HttpNotFound();
            }
            return View(sex);
        }

        // POST: sexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sex,name")] sex sex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sex);
        }

        // GET: sexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sex sex = db.sexs.Find(id);
            if (sex == null)
            {
                return HttpNotFound();
            }
            return View(sex);
        }

        // POST: sexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sex sex = db.sexs.Find(id);
            db.sexs.Remove(sex);
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
