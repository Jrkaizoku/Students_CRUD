using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Students_CRUD.Models;

namespace Students_CRUD.Controllers
{
    public class SubjectsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Subjects
        public ActionResult Index()
        {
            
            ViewBag.Subject = db.Subject.ToList();
            return View();
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.Teacher = db.Teacher.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Subject subject, int teacher)
        {
            
            if (ModelState.IsValid)
            {
                db.Subject.Add(subject);
                db.SaveChanges();
                Teacher_Subject _Subject = new Teacher_Subject();
                _Subject.id_subject = subject.id;
                _Subject.id_teacher = teacher;
                db.Teacher_Subject.Add(_Subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subject.Find(id);
            db.Subject.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
