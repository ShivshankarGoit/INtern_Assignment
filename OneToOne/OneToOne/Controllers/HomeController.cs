using OneToOne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneToOne.Controllers
{
    public class HomeController : Controller
    {
        private User_detailEntities db = new User_detailEntities();

        // GET: UserProfiles
        public ActionResult Index()
        {
            var userProfiles = db.user_profiles.Include(u => u.user).ToList();
            return View(userProfiles);
        }

        

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName");
            return View();
        }

        // POST: UserProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user userProfile)
        {
            if (ModelState.IsValid)
            {

                db.users.Add(userProfile);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", userProfile.user_id);
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user userProfile = db.users.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", userProfile.user_id);
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        [HttpPost]

        public ActionResult Edit(int? id, user userProfile)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                var user = db.users.Find(id);
                user.username = userProfile.username;
                user.user_profiles.profile_data = userProfile.user_profiles.profile_data;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.users, userProfile.user_id);
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user userProfile = db.users.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            user userProfile = db.users.Find(id);
            db.user_profiles.Remove(userProfile.user_profiles);
                db.users.Remove(userProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}