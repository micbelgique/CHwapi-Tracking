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
    public class TrackedItemsController : ApiController
    {
        private TrackerEntities db = new TrackerEntities();

        // GET: api/TrackedItems
        public IQueryable<TrackedItem> GetTrackedItem()
        {
            return db.TrackedItem;
        }

        // GET: api/TrackedItems/5
        [ResponseType(typeof(TrackedItem))]
        public IHttpActionResult GetTrackedItem(int id)
        {
            TrackedItem trackedItem = db.TrackedItem.Find(id);
            if (trackedItem == null)
            {
                return NotFound();
            }

            return Ok(trackedItem);
        }

        // PUT: api/TrackedItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrackedItem(int id, TrackedItem trackedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackedItem.ID)
            {
                return BadRequest();
            }

            db.Entry(trackedItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackedItemExists(id))
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

        // POST: api/TrackedItems
        [ResponseType(typeof(TrackedItem))]
        public IHttpActionResult PostTrackedItem(TrackedItem trackedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrackedItem.Add(trackedItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trackedItem.ID }, trackedItem);
        }

        // DELETE: api/TrackedItems/5
        [ResponseType(typeof(TrackedItem))]
        public IHttpActionResult DeleteTrackedItem(int id)
        {
            TrackedItem trackedItem = db.TrackedItem.Find(id);
            if (trackedItem == null)
            {
                return NotFound();
            }

            db.TrackedItem.Remove(trackedItem);
            db.SaveChanges();

            return Ok(trackedItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackedItemExists(int id)
        {
            return db.TrackedItem.Count(e => e.ID == id) > 0;
        }
    }
}