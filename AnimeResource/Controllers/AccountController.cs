using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimeResource.Models;

namespace AnimeResource.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private AnimeContext db = new AnimeContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "animes");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "animes");
        }

        // GET: users/Create
        public ActionResult Register()
        {
            ViewBag.id_user = new SelectList(db.profiles, "id_user", "name");
            ViewBag.id_role = new SelectList(db.roles, "id_role", "name");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id_user,login,pasword,e_mail,confirmed,id_role")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.profiles, "id_user", "name", user.id_user);
            ViewBag.id_role = new SelectList(db.roles, "id_role", "name", user.id_role);
            return View(user);
        }

        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;

            using (AnimeContext _db = new AnimeContext())
            {
                try
                {
                    user user = (from u in _db.users
                                 where u.login == login && u.pasword == password
                                 select u).FirstOrDefault();

                    if (user != null)
                    {
                        isValid = true;
                    }
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}