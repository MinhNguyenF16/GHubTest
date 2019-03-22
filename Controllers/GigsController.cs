using GHub.Models;
using GHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost] // want this action to be called by only the post method
        public ActionResult Create(GigFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
                //var artistId = User.Identity.GetUserId(); // turns id to int

                // read from database
                // var artist = _context.Users.Single(u => u.Id == artistId); // this lambada expression can be converted to sql because it's an int now
                //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);
                // no longer needed after using artistId and GenreId
                //Hello123.
                var gig = new Gig
            {
                // need application user object here
                ArtistId = User.Identity.GetUserId(),
                //need to pass info somewhere else, controller should not do all the work
                //DateTime = DateTime.Parse(string.Format("{0}{1}", viewModel.Date, viewModel.Time)),
                DateTime = viewModel.GetDateTime() ,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            // run sql statement and save it on database
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}