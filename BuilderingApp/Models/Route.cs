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
        public double Coordinate { get; set; }
        public string Description { get; set; }
        public object Topo { get; set; }
        public string Rating { get; set; }
        public string Grade { get; set; }
        public object Photo { get; set; }
        public string Comments { get; set; }
        public string User { get; set; }
        public string Video { get; set; }
    }
    
    public class RouteDBContext : DbContext
    {
        public DbSet <Route> Routes { get; set; }
    }
}