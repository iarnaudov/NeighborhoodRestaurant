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

        public List<Statistics> GetVIPUsersStatistics()
        {
            List<Statistics> statistics = new List<Statistics>();
            List<Order> orders = this.databaseCtx.Orders.ToList();
            var users = this.databaseCtx.Users.ToList();
            List<Meal> meals = this.databaseCtx.Meals.ToList();
            List<Data.DataModels.JoinTable> allJoinedOrders = this.databaseCtx.JoinTable.FromSqlRaw(@"SELECT * FROM Orders LEFT JOIN MealOrders on Orders.Id = MealOrders.OrderId").ToList();
            List<IGrouping<int, (int MealId, string UserId)>> groupedByWeekDay = allJoinedOrders.GroupBy(o => o.DayOfWeek, o => (o.MealId, o.UserId)).ToList();

            foreach (IGrouping<int, (int MealId, string UserId)> weekdayMeals in groupedByWeekDay)
            {
                Statistics dayStats = new Statistics()
                {
                    DayOfWeek = (DayOfWeek)weekdayMeals.Key,
                    Meals = new List<MealStatistic>(),
                };

                List<IGrouping<int, (int MealId, string UserId)>> groupedDailyMeals = weekdayMeals.GroupBy(m => m.MealId).ToList();

                foreach (IGrouping<int, (int MealId, string UserId)> meal in groupedDailyMeals)
                {
                    dayStats.Meals.Add(new MealStatistic()
                    {
                        MealName = meals.Where(m => m.Id == meal.Key).FirstOrDefault().Name,
                        PictureLink = meals.Where(m => m.Id == meal.Key).FirstOrDefault().PictureUrl,
                        Count = meal.Select(m => m.MealId).Count(),
                        UserIds = meal.Select(m => users.Where(u => u.Id == m.UserId).First().UserName).ToList()
                    }); 
                }
                dayStats.Meals = dayStats.Meals.OrderByDescending(m => m.Count).ToList();
                statistics.Add(dayStats);
            }
            return statistics;
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
