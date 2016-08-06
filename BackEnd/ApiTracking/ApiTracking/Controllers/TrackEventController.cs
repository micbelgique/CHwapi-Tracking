using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiTracking.Models;
using System.Data.Entity.Infrastructure;
using log4net;
using System.Reflection;

namespace ApiTracking.Controllers
{
    public class TrackEventController : ApiController
    {
        private TrackerEntities db = new TrackerEntities();
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Enum

        public enum TrackStatus { Open = 1, Closed }

        #endregion

        public class MessageRequest
        {
            public int boxid { get; set; }            
        }
        public class EventRequest
        {
            public int gateid { get; set; }
            public MessageRequest message { get; set; }            
        }

        // POST: api/Event
        [ResponseType(typeof(TrackHistory))]
        public IHttpActionResult AddEvent(EventRequest eRequest)
        {
            //contrôle des données passées
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transactionScope = db.Database.BeginTransaction())
            {
                try
                {
                    //Détermination du track en cours lié à la boîtez            
                    Track track = db.Track.SingleOrDefault<Track>(t => t.BoxID == eRequest.message.boxid && t.Status == (int)TrackStatus.Open);
                    if (track == null)
                    {
                        return NotFound(); //Si aucun track en cours (boîte vide) - ne pas prendre en compte l'évent
                    }
                        
                    //Déterminer si parcours terminé
                    if (track.GateID == eRequest.gateid)
                    {
                        track.Status = (int)TrackStatus.Closed; //Ajustement du status du track (fermeture)
                    }

                    //Sauvegarde de l'évènement
                    TrackHistory trackHistory = new TrackHistory();
                    trackHistory.GateID = eRequest.gateid;
                    trackHistory.TrackID = track.ID;
                    trackHistory.ScanTime = DateTime.Now;
                    db.TrackHistory.Add(trackHistory);

                    db.SaveChanges();

                    transactionScope.Commit();
                    return CreatedAtRoute("DefaultApi", new { id = trackHistory.ID }, trackHistory);
                }
                catch (Exception e)
                {
                    transactionScope.Rollback();
                    log.ErrorFormat("{0} : {1}{2} | {3}", "Erreur lors de la transaction d'ajout d'un track event", "GET: Api/TrackEvent/", MethodBase.GetCurrentMethod().Name, e.ToString());
                    return null;
                }
            }

            return null;
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
