using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission05.Models;

namespace Mission05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieSubmissionContext _xContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieSubmissionContext x)
        {
            _logger = logger;
            _xContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _xContext.Categories
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieSubmission ms)
        {
            if (ModelState.IsValid)
            {
                _xContext.Add(ms);
                _xContext.SaveChanges();
                return View("Confirmation", ms);
            }
            else
            {
                ViewBag.Categories = _xContext.Categories
                    .ToList();

                return View();
            }
            
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _xContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _xContext.Categories
                .ToList();

            var submission = _xContext.Responses
                .Single(x => x.MovieID == movieid);

            return View("MovieForm", submission);
        }

        [HttpPost]
        public IActionResult Edit(MovieSubmission ms)
        {
            _xContext.Update(ms);
            _xContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var submission = _xContext.Responses
                .Single(x => x.MovieID == movieid);

            return View(submission);
        }

        [HttpPost]
        public IActionResult Delete(MovieSubmission ms)
        {
            _xContext.Responses.Remove(ms);
            _xContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


    }
}
