using Microsoft.EntityFrameworkCore;
using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Data.DTOs;
using NeighborhoodRestaurant.Data.Enums;
using NeighborhoodRestaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeighborhoodRestaurant.Services
{
    public class MealService
    {
        private readonly RestaurantDbContext databaseCtx;
        private readonly OrderService orderService;

        public MealService(RestaurantDbContext databaseContext)
        {
            this.databaseCtx = databaseContext;
            this.orderService = new OrderService(databaseContext);
        }

        public List<Meal> GetMeals(MealType mealType)
        {
            return this.databaseCtx.Meals.Where(m => m.MealType == mealType).ToList();
        }

        public List<MostWantedMeal> GetMostOrderedMeals()
        {
            List<MostWantedMeal> mostWantedMeals = new List<MostWantedMeal>();
            List<Meal> meals = this.databaseCtx.Meals.ToList();
            List<MealOrder> allOrders = this.orderService.GetAllOrders();
            List<IGrouping<int, MealOrder>> grouped = allOrders.GroupBy(o => o.MealId).OrderByDescending(meals => meals.Count()).ToList();

            foreach (IGrouping<int, MealOrder> item in grouped)
            {
                mostWantedMeals.Add(new MostWantedMeal()
                {
                    MealName = meals.Where(m => m.Id == item.Key).FirstOrDefault().Name,
                    PictureLink = meals.Where(m => m.Id == item.Key).FirstOrDefault().PictureUrl,
                    OrderCount = item.Count()
                });
            }
            return mostWantedMeals;
        }

        public void GetVIPUsersStatistics()
        {
            var allOrders = this.databaseCtx.JoinTable.FromSqlRaw(@"SELECT * FROM Orders LEFT JOIN MealOrders on Orders.Id = MealOrders.OrderId").ToList();

        }



    public List<int> GetSomeMeals()
    {
        List<int> mealsids = new List<int>();
        mealsids.Add(this.databaseCtx.Meals.Where(m => m.MealType == MealType.Appetizer).First().Id);
        mealsids.Add(this.databaseCtx.Meals.Where(m => m.MealType == MealType.MainCourse).First().Id);
        mealsids.Add(this.databaseCtx.Meals.Where(m => m.MealType == MealType.Dessert).First().Id);
        return mealsids;
    }
}
}
