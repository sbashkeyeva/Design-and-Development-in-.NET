using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Movie
    {
        
            public int ID { get; set; }
            public double Rating { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
        
    }
}