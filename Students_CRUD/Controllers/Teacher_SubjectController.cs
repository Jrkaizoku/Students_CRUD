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
    public class Teacher_SubjectController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Teacher_Subject
        public ActionResult Index()
        {
            return View(db.Teacher_Subject.ToList());
        }

        // GET: Teacher_Subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher_Subject teacher_Subject = db.Teacher_Subject.Find(id);
            if (teacher_Subject == null)
            {
                return HttpNotFound();
            }
            return View(teacher_Subject);
        }

        // GET: Teacher_Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher_Subject/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_teacher,id_subject")] Teacher_Subject teacher_Subject)
        {
            if (ModelState.IsValid)
            {
                db.Teacher_Subject.Add(teacher_Subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher_Subject);
        }

        // GET: Teacher_Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher_Subject teacher_Subject = db.Teacher_Subject.Find(id);
            if (teacher_Subject == null)
            {
                return HttpNotFound();
            }
            return View(teacher_Subject);
        }

        // POST: Teacher_Subject/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_teacher,id_subject")] Teacher_Subject teacher_Subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher_Subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher_Subject);
        }

        // GET: Teacher_Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher_Subject teacher_Subject = db.Teacher_Subject.Find(id);
            if (teacher_Subject == null)
            {
                return HttpNotFound();
            }
            return View(teacher_Subject);
        }

        // POST: Teacher_Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher_Subject teacher_Subject = db.Teacher_Subject.Find(id);
            db.Teacher_Subject.Remove(teacher_Subject);
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
