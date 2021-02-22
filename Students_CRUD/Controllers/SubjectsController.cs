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
<<<<<<< HEAD
            
            ViewBag.Subject = db.Subject.ToList();
            return View();
=======
            return View(db.Subject.ToList());
>>>>>>> 40cbb8848b5e549c619cb9f5a310519745663a30
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
<<<<<<< HEAD
            ViewBag.Teacher = db.Teacher.ToList();

=======
>>>>>>> 40cbb8848b5e549c619cb9f5a310519745663a30
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create([Bind(Include = "id,name")] Subject subject, int teacher)
        {
            
=======
        public ActionResult Create([Bind(Include = "id,name")] Subject subject)
        {
>>>>>>> 40cbb8848b5e549c619cb9f5a310519745663a30
            if (ModelState.IsValid)
            {
                db.Subject.Add(subject);
                db.SaveChanges();
<<<<<<< HEAD
                Teacher_Subject _Subject = new Teacher_Subject();
                _Subject.id_subject = subject.id;
                _Subject.id_teacher = teacher;
                db.Teacher_Subject.Add(_Subject);
                db.SaveChanges();
=======
>>>>>>> 40cbb8848b5e549c619cb9f5a310519745663a30
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
