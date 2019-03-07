using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVCDemoApplication.Models;

namespace WebMVCDemoApplication.Controllers
{
    public class UserAccessesController : Controller
    {
        private db_TestEntities db = new db_TestEntities();

        // GET: UserAccesses
        public ActionResult Index()
        {
            return View(db.UserAccess.ToList());
        }

        // GET: UserAccesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccess userAccess = db.UserAccess.Find(id);
            if (userAccess == null)
            {
                return HttpNotFound();
            }
            return View(userAccess);
        }

        // GET: UserAccesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccesses/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Password")] UserAccess userAccess)
        {
            if (ModelState.IsValid)
            {
                db.UserAccess.Add(userAccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccess);
        }

        // GET: UserAccesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccess userAccess = db.UserAccess.Find(id);
            if (userAccess == null)
            {
                return HttpNotFound();
            }
            return View(userAccess);
        }

        // POST: UserAccesses/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Password")] UserAccess userAccess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccess);
        }

        // GET: UserAccesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccess userAccess = db.UserAccess.Find(id);
            if (userAccess == null)
            {
                return HttpNotFound();
            }
            return View(userAccess);
        }

        // POST: UserAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccess userAccess = db.UserAccess.Find(id);
            db.UserAccess.Remove(userAccess);
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
