using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Data.Enums;
using NeighborhoodRestaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeighborhoodRestaurant.Services
{
    public class OrderService
    {
        private readonly RestaurantDbContext databaseCtx;

        public OrderService(RestaurantDbContext databaseContext)
        {
            this.databaseCtx = databaseContext;
        }


        public bool UserHasOrderForTheDay(string UserId, DayOfWeek DayOfWeek)
        {
            return this.databaseCtx.Orders.Where(o => o.UserId == UserId && o.DayOfWeek == DayOfWeek).ToList().Count() > 0;
        }

        public List<MealOrder> GetAllOrders()
        {
            return this.databaseCtx.MealOrders.ToList();
        }

        public void PlaceOrder(DayOfWeek DayOfTheWeek, string userId, ICollection<int> mealIds)
        {
            Order order = new Order();
            order.DayOfWeek = DayOfTheWeek;
            order.UserId = userId;

            this.databaseCtx.Add(order);
            this.databaseCtx.SaveChanges();
            int orderId = this.databaseCtx.Orders.Max(i => i.Id);

            foreach (var mealId in mealIds)
            {
                MealOrder mealOrder = new MealOrder();
                mealOrder.MealId = mealId;
                mealOrder.OrderId = orderId;
                this.databaseCtx.Add(mealOrder);
                this.databaseCtx.SaveChanges();
            }
        }
    }
}
