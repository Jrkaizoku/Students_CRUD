using Students_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students_CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentContext db = new StudentContext();
           
            return View(db.Student.ToList());
        }

        // GET: Student/Details/5

        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                using (var db = new StudentContext())
                {
                    student.registration_date = DateTime.Now;
                    db.Student.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error al ingresar el alumno", e);
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            try {
                using (var db = new StudentContext())
                {
                    Student student = db.Student.Find(id);
                    return View(student);
                }
            }
            catch    {
                throw;
            }
           
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (var db = new StudentContext())
                {
                    Student stud = db.Student.Find(id);
                    stud.name = student.name;
                    stud.last_name = student.last_name;
                    stud.age = student.age;
                    stud.gender = student.gender;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

               
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id) {
            using (var db = new StudentContext())
            {
                Student stud = db.Student.Find(id);

                return View(stud);
            }
        }

        // GET: Student/Delete/5
    
     
        public ActionResult Delete(int id)
        {
           
                using (var db = new StudentContext())
                {
                    Student stud = db.Student.Find(id);
                    db.Student.Remove(stud);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
           
        }
    }
}
