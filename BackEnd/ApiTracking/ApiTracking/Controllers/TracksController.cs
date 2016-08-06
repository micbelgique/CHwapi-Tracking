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
    public class TracksController : ApiController
    {
        private TrackerEntities db = new TrackerEntities();

        // GET: api/Tracks
        public IQueryable<Track> GetTrack()
        {
            return db.Track;
        }

        // GET: api/Tracks/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult GetTrack(int id)
        {
            Track track = db.Track.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // PUT: api/Tracks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrack(int id, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.ID)
            {
                return BadRequest();
            }

            db.Entry(track).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Tracks
        [ResponseType(typeof(Track))]
        public IHttpActionResult PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Track.Add(track);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = track.ID }, track);
        }

        // DELETE: api/Tracks/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult DeleteTrack(int id)
        {
            Track track = db.Track.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            db.Track.Remove(track);
            db.SaveChanges();

            return Ok(track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackExists(int id)
        {
            return db.Track.Count(e => e.ID == id) > 0;
        }
    }
}