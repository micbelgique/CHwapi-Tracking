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
    public class TrackHistoriesController : ApiController
    {
        private TrackerEntities db = new TrackerEntities();

        // GET: api/TrackHistories
        public IQueryable<TrackHistory> GetTrackHistory()
        {
            return db.TrackHistory;
        }

        // GET: api/TrackHistories/5
        [ResponseType(typeof(TrackHistory))]
        public IHttpActionResult GetTrackHistory(int id)
        {
            TrackHistory trackHistory = db.TrackHistory.Find(id);
            if (trackHistory == null)
            {
                return NotFound();
            }

            return Ok(trackHistory);
        }

        // PUT: api/TrackHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrackHistory(int id, TrackHistory trackHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackHistory.ID)
            {
                return BadRequest();
            }

            db.Entry(trackHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackHistoryExists(id))
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

        // POST: api/TrackHistories
        [ResponseType(typeof(TrackHistory))]
        public IHttpActionResult PostTrackHistory(TrackHistory trackHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrackHistory.Add(trackHistory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trackHistory.ID }, trackHistory);
        }

        // DELETE: api/TrackHistories/5
        [ResponseType(typeof(TrackHistory))]
        public IHttpActionResult DeleteTrackHistory(int id)
        {
            TrackHistory trackHistory = db.TrackHistory.Find(id);
            if (trackHistory == null)
            {
                return NotFound();
            }

            db.TrackHistory.Remove(trackHistory);
            db.SaveChanges();

            return Ok(trackHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackHistoryExists(int id)
        {
            return db.TrackHistory.Count(e => e.ID == id) > 0;
        }
    }
}