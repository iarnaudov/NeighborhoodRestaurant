using Microsoft.AspNetCore.Identity;
using NeighborhoodRestaurant.Data.Enums;
using System;
using System.Collections.Generic;

namespace NeighborhoodRestaurant.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string UserId { get; set; }
        public ICollection<MealOrder> MealOrders { get; set; }
    }
}
