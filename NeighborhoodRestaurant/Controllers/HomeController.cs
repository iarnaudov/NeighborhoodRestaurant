using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Services;
using NeighborhoodRestaurant.ViewModels;

namespace NeighborhoodRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantDbContext databaseCtx;

        public HomeController(ILogger<HomeController> logger, RestaurantDbContext databaseContext)
        {
            _logger = logger;
            this.databaseCtx = databaseContext;
        }

        public IActionResult Index()
        {
            var meals = this.databaseCtx.Meals.ToList();
            if (meals.Count == 0)
            {
                SeedService.SeedData(this.databaseCtx);
            }
            return View();
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
