using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodRestaurant.Data.Models
{
    public class MealOrder
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
