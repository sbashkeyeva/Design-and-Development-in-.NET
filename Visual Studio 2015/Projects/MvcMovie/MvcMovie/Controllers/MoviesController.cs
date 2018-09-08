using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;
using System.IO;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MvcMovieContext db = new MvcMovieContext();
        string[] lines = System.IO.File.ReadAllLines(@"\\Mac\Home\Downloads\listofmovies.txt");
        
        // GET: Movies
        public ActionResult _new()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            foreach (string line in lines)
            {
                string[] word= line.Split(' ');
                Console.WriteLine(word);

            }

            return View();
            //return View(db.Movies.ToList());
        }


    }
}
