using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Data.Enums;
using NeighborhoodRestaurant.Services;
using NeighborhoodRestaurant.Web.ViewModels;
using System;

namespace NeighborhoodRestaurant.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly RestaurantDbContext databaseCtx;
        private readonly DateService dateService;
        private readonly MealService mealService;

        public MenuController(RestaurantDbContext databaseContext)
        {
            this.databaseCtx = databaseContext;
            this.dateService = new DateService(databaseContext);
            this.mealService = new MealService(databaseContext);
        }

        public IActionResult Index()
        {
            string userId = HttpContext.User.Identity.GetUserId();
            SelectMenuViewModel viewModel = new SelectMenuViewModel()
            {
                WeekDays = this.dateService.GetCustomerOrdersForTheWeek(userId),
                Appetizers = this.mealService.GetMeals(MealType.Appetizer),
                MainCourses = this.mealService.GetMeals(MealType.MainCourse),
                Desserts = this.mealService.GetMeals(MealType.Dessert),
            };
            return View(viewModel);
        }
    }
}
