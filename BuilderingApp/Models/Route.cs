using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BuilderingApp.Models
{
    public class Route
    {
       
        public int ID { get; set; }
        public string name { get; set; }
        public string Coordinate { get; set; }
        public string Description { get; set; }
        public object Topo { get; set; }
        public string Rating { get; set; }
        public string Grade { get; set; }
        public object Photo { get; set; } // Will likely have to change to an array/list 
        public string Comments { get; set; } // Will likely have to change to an array/list 
        public string User { get; set; }
        public string Video { get; set; }
    }
    
    public class RouteDBContext : DbContext
    {
        public DbSet <Route> Routes { get; set; }

        public RouteDBContext() : base("RouteDBContext")
        {
            Database.SetInitializer(new BuilderingInitializer());
        }
    }
    public class BuilderingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RouteDBContext>
    {
        protected override void Seed(RouteDBContext context)
        {
            Route route1 = new Route()
            {
                ID = 1,
                Description = "climb up",
                User = "me",
                Grade = "5c",
                Coordinate = "53.37781949080278,-1.470623016357422",
                Comments = "a comment",
                name = "a climb",
                Rating = "4 start"
            };
            context.Routes.Add(route1);
            context.SaveChanges();
        }
    }


}