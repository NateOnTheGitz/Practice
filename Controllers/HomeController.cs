using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {

        private IMovieRepository _repo { get; set; }

        public HomeController(IMovieRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var data = _repo.MovieInfos
                .ToList();

            var second = _repo.MovieInfos.Include(x => x.Category).ToList();

            return View(second);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieInfo MI)
        {
            if(ModelState.IsValid)
            {
                _repo.AddMovie(MI);
                _repo.Save();

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();
                return View(MI);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _repo.Categories.ToList();

            var record = _repo.GetMovieByID(id);

            return View("Create", record);
        }

        [HttpPost]
        public IActionResult Edit(MovieInfo MI)
        {
            if(ModelState.IsValid)
            {
                _repo.EditMovie(MI);
                _repo.Save();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();
                return View("Create", MI);
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _repo.GetMovieByID(id);

            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(MovieInfo MI)
        {
            _repo.DeleteMovie(MI);
            _repo.Save();

            return RedirectToAction("List");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
