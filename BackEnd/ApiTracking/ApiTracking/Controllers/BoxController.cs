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
using ApiTracking.Models;

namespace ApiTracking.Controllers
{
    public class BoxController : ApiController
    {
        private TrackerEntities db = new TrackerEntities();

        // GET: api/Boxes
        public IQueryable<Box> GetBox()
        {
            return db.Box;
        }

        // GET: api/Boxes/5
        [ResponseType(typeof(Box))]
        public IHttpActionResult GetBox(int id)
        {
            Box box = db.Box.Find(id);
            if (box == null)
            {
                return NotFound();
            }

            return Ok(box);
        }

        // PUT: api/Boxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBox(int id, Box box)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != box.ID)
            {
                return BadRequest();
            }

            db.Entry(box).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxExists(id))
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

        // POST: api/Boxes
        [ResponseType(typeof(Box))]
        public IHttpActionResult PostBox(Box box)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.Box.Any<Box>(b => b.Barcode == box.Barcode))
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            db.Box.Add(box);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = box.ID }, box);
        }

        // DELETE: api/Boxes/5
        [ResponseType(typeof(Box))]
        public IHttpActionResult DeleteBox(int id)
        {
            Box box = db.Box.Find(id);
            if (box == null)
            {
                return NotFound();
            }

            db.Box.Remove(box);
            db.SaveChanges();

            return Ok(box);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoxExists(int id)
        {
            return db.Box.Count(e => e.ID == id) > 0;
        }
    }
}