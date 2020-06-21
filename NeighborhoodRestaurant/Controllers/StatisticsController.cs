using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Services;

namespace NeighborhoodRestaurant.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly RestaurantDbContext databaseCtx;
        private readonly MealService mealService;

        public StatisticsController(RestaurantDbContext databaseContext)
        {
            this.databaseCtx = databaseContext;
            this.mealService = new MealService(databaseContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostWanted()
        {
            List<Data.DTOs.MostWantedMeal> meals = this.mealService.GetMostOrderedMeals();
            return View(meals);
        }

        public IActionResult FullStatistics()
        {
            List<Data.DTOs.Statistics> statistics = this.mealService.GetVIPUsersStatistics();
            return View(statistics);
        }
    }
}