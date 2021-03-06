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
    public class NotesController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Notes
        public ActionResult Index()
        {
            var notes = db.Notes.Include(n => n.Student).Include(n => n.Subject);
            return View(notes.ToList());
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notes notes = db.Notes.Find(id);
            if (notes == null)
            {
                return HttpNotFound();
            }
            return View(notes);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            ViewBag.id_student = new SelectList(db.Student, "id", "name");
            ViewBag.id_subject = new SelectList(db.Subject, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "id_student,id_subject,exam1,homework,exam2")] Notes notes)
        {
            notes.avg = (notes.exam1 + notes.exam2 + notes.homework) / 3;
            Console.WriteLine(notes.avg);
            if (ModelState.IsValid)
            {
              
                db.Notes.Add(notes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_student = new SelectList(db.Student, "id", "name", notes.id_student);
            ViewBag.id_subject = new SelectList(db.Subject, "id", "name", notes.id_subject);
            return View(notes);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notes notes = db.Notes.Find(id);
            if (notes == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_student = new SelectList(db.Student, "id", "name", notes.id_student);
            ViewBag.id_subject = new SelectList(db.Subject, "id", "name", notes.id_subject);
            return View(notes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "id,id_student,id_subject,exam1,homework,exam2")] Notes notes)
        {
            notes.avg = (notes.exam1 + notes.exam2 + notes.homework) / 3;
            if (ModelState.IsValid)
            {
                db.Entry(notes).State = EntityState.Modified;
               

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_student = new SelectList(db.Student, "id", "name", notes.id_student);
            ViewBag.id_subject = new SelectList(db.Subject, "id", "name", notes.id_subject);
            return View(notes);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notes notes = db.Notes.Find(id);
            if (notes == null)
            {
                return HttpNotFound();
            }
            return View(notes);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notes notes = db.Notes.Find(id);
            db.Notes.Remove(notes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
