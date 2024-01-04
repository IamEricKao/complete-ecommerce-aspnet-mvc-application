using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            //var allMovies = await _context.Movies
            //    .Include(c => c.Cinema)
            //    .OrderBy(n => n.Name)
            //    .ToListAsync();
            return View(allMovies);
        }

        //GET:Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            if (movieDetail == null) return View();
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            return View();
        }
    }
}