using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Data.DTOs;
using NeighborhoodRestaurant.Services;
using System;

namespace NeighborhoodRestaurant.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly RestaurantDbContext databaseCtx;

        public OrderController(RestaurantDbContext databaseContext)
        {
            this.databaseCtx = databaseContext;
        }   

        [HttpPost]
        public void PlaceOrder([FromBody]OrderRequest request)
        {
            string userId = HttpContext.User.Identity.GetUserId();
            var orderService = new OrderService(this.databaseCtx);
            orderService.PlaceOrder((DayOfWeek)request.WeekDay, userId, request.Meals);
        }
    }
}
