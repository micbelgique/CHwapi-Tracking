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
            public int boxid { get; set; }
            public int status { get; set; }
        }
        public class HistoryResponse
        {
            public List<Track> Tracks { get; set; }
        }

        
        [ResponseType(typeof(HistoryResponse))]
        public IHttpActionResult History(HistoryRequest hRequest)
        {
            //contrôle des données passées
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                HistoryResponse sResponse = new HistoryResponse();
                List<Track> tracks = new List<Track>();                

                //Recherche de tracks associées à la boîte
                tracks = db.Track.Where(t => t.BoxID == hRequest.boxid).OrderBy(t => t.ID).ToList<Track>();
                
                //Embarquer l'history par ordre chronologique dans chaque track            
                foreach (Track track in tracks)
                {
                    var trackHistory = track.TrackHistory;
                    track.TrackHistory = trackHistory.OrderBy(th => th.ScanTime).ToList();
                }

                //Préparation réponse
                sResponse.Tracks = tracks;                

                return Ok(sResponse);
            }
            catch (Exception e)
            {
                log.ErrorFormat("{0} : {1}{2} | {3}", "Erreur lors de la recherche", "GET: Api/TrackAdmin/", MethodBase.GetCurrentMethod().Name, e.ToString());
                return InternalServerError();
            }
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
