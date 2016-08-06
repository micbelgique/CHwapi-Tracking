using ApiTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiTracking.App_Start
{
    public class DatabaseInitializer
    {

        private TrackerEntities context = new TrackerEntities();

        public void Seed()
        {
            //// Seeding Datas
            // Gates
            context.Gate.Add(new Gate() { Description = "Accueil Site n°1", X = 0, Y = 1, Z = 2 });
            context.Gate.Add(new Gate() { Description = "Accueil Site n°2", X = 0, Y = 2, Z = 2 });
            context.Gate.Add(new Gate() { Description = "Accueil Site n°3", X = 0, Y = 3, Z = 2 });
            context.Gate.Add(new Gate() { Description = "Laboratoire Site n°1", X = 1, Y = 1, Z = 2 });
            context.Gate.Add(new Gate() { Description = "Pharmacie Site n°2", X = 2, Y = 2, Z = 2 });

            // Boxes
            context.Box.Add(new Box() { Description = "Container de médicaments", Barcode = "BOX-0001" });
            context.Box.Add(new Box() { Description = "Container de matériel stérilisé", Barcode = "BOX-0002" });
            context.Box.Add(new Box() { Description = "Container de documents", Barcode = "BOX-0003" });

            // Items
            context.Item.Add(new Item() { Description = "Aspriine 500mg x20", Barcode = "5410013111009" });
            context.Item.Add(new Item() { Description = "Flamagel sans cortizone 100ml", Barcode = "5410013101000" });
            context.Item.Add(new Item() { Description = "Fiole laboratoire n°9876541", Barcode = "640522710850" });

            // Users
            context.User.Add(new User() { Username = "procl0905" });
            context.User.Add(new User() { Username = "devaa1911" });
            context.User.Add(new User() { Username = "overworks" });

            context.SaveChanges();
        }
    }
}