using ApiTracking.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace ApiTracking.Controllers
{
    public class TrackAdminController : ApiController
    {

        private TrackerEntities db = new TrackerEntities();
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public class SearchRequest
        {
            public string search { get; set; }            
        }
        public class SearchResponse
        {
            public List<Box> boxes { get; set; }
            public List<Item> items { get; set; }
        }

        [ResponseType(typeof(SearchResponse))]
        public IHttpActionResult Search(SearchRequest sRequest)
        {
            //contrôle des données passées
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                SearchResponse sResponse = new SearchResponse();
                List<Box> boxes = new List<Box>();
                List<Item> items = new List<Item>();
        
                //Recherche de boîtes
                boxes = db.Box.Where(b => b.Barcode.Contains(sRequest.search) || b.Description.Contains(sRequest.search)).ToList<Box>();

                //Recherche d'un item
                items = db.Item.Where(i => i.Barcode.Contains(sRequest.search) || i.Description.Contains(sRequest.search)).ToList<Item>();

                //Préparation réponse
                sResponse.boxes = boxes;
                sResponse.items = items;

                return Ok(sResponse);
            }
            catch (Exception e)
            {
                log.ErrorFormat("{0} : {1}{2} | {3}", "Erreur lors de la recherche", "GET: Api/TrackAdmin/", MethodBase.GetCurrentMethod().Name, e.ToString());
            }

            return null;
        }

        public class HistoryRequest
        {
            public string history { get; set; }
        }
        public class HistoryResponse
        {
            public List<Track> Tracks { get; set; }
        }

        
        [ResponseType(typeof(Track))]
        public IHttpActionResult History(HistoryRequest hRequest)
        {
            try
            {
                Track track = db.Track.OrderByDescending<Track, int>(t => t.ID).First<Track>(t => t.Box.Barcode == hRequest.history);

                return Ok(track);
            }
            catch (Exception e)
            {
                log.ErrorFormat("{0} : {1}{2} | {3}", "Erreur lors de la recherche historique", "GET: Api/TrackAdmin/History", MethodBase.GetCurrentMethod().Name, e.ToString());
                return InternalServerError();
            }
        }


        #region Enum

        public enum TrackStatus { Open = 1, Closed }

        #endregion
        public class CreateRequest
        {           
            
            public Box box { get; set; }
            public List<Item> items { get; set; }
        }
        public class CreateResponse
        {            
            public Box box { get; set; }
            public List<Item> items { get; set; }
        }
        [ResponseType(typeof(Track))]
        public IHttpActionResult CreateBox(CreateRequest cRequest)
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
                    //Ajout des items
                    foreach (Item item in cRequest.items)
                    {
                        db.Item.Add(item);                        
                    }

                    db.SaveChanges();

                    CreateResponse cResponse = new CreateResponse();
                    cResponse.box = cRequest.box;
                    cResponse.items = cRequest.items;

                    transactionScope.Commit();

                    return Ok(cResponse);
                }
                catch (Exception e)
                {
                    transactionScope.Rollback();
                    log.ErrorFormat("{0} : {1}{2} | {3}", "Erreur lors de la recherche", "GET: Api/TrackAdmin/", MethodBase.GetCurrentMethod().Name, e.ToString());
                }
            }

            return null;
        }

        public class AffectRequest
        {
            public int gateid { get; set; }
            public int boxid { get; set; }
            public List<int> itemsid { get; set; }
        }
        [ResponseType(typeof(Track))]
        public IHttpActionResult AffectBox(AffectRequest cRequest)
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
                    //Ajout du track
                    Track track = new Track();
                    track.BoxID = cRequest.boxid;
                    track.GateID = cRequest.gateid;
                    track.UserID = 5; //On n'a pas la partie d'identification donc faudra l'implémenter et passer le user dans les params
                    track.Status = (int)TrackStatus.Open;

                    //Ajout des items
                    foreach (int itemid in cRequest.itemsid)
                    {
                        var vTempTI = track.TrackedItem.FirstOrDefault<TrackedItem>(ti => ti.ItemID == itemid);
                        if (vTempTI != null)
                        {
                            ++vTempTI.Quantity;
                        }
                        else
                        {
                            TrackedItem trackedItem = new TrackedItem() { ItemID = itemid, Track = track, Quantity = 1 };
                            track.TrackedItem.Add(trackedItem);
                        }
                    }

                    db.Track.Add(track);
                    db.SaveChanges();

                    // Track History
                    TrackHistory trackHistory = new TrackHistory() { ScanTime = DateTime.Now, Track = track };
                    db.TrackHistory.Add(trackHistory);
                    db.SaveChanges();

                    transactionScope.Commit();

                    return Ok(track);
                }
                catch (Exception e)
                {
                    transactionScope.Rollback();
                    log.ErrorFormat("{0} : {1}{2} | {3}", "Erreur lors de la recherche", "GET: Api/TrackAdmin/", MethodBase.GetCurrentMethod().Name, e.ToString());
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
