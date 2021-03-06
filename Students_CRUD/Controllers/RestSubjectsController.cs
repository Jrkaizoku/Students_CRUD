using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Students_CRUD.Models;

namespace Students_CRUD.Controllers
{
    public class RestSubjectsController : ApiController
    {
        private StudentContext db = new StudentContext();

        // GET: api/RestSubjects
        public IQueryable<Subject> GetSubject()
        {
            return db.Subject;
        }

        // GET: api/RestSubjects/5
        [ResponseType(typeof(Subject))]
        public IHttpActionResult GetSubject(int id)
        {
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/RestSubjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubject(int id, Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.id)
            {
                return BadRequest();
            }

            db.Entry(subject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RestSubjects
        [ResponseType(typeof(Subject))]
        public IHttpActionResult PostSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subject.Add(subject);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subject.id }, subject);
        }

        // DELETE: api/RestSubjects/5
        [ResponseType(typeof(Subject))]
        public IHttpActionResult DeleteSubject(int id)
        {
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            db.Subject.Remove(subject);
            db.SaveChanges();

            return Ok(subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectExists(int id)
        {
            return db.Subject.Count(e => e.id == id) > 0;
        }
    }
}