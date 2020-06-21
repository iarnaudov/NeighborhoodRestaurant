using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodRestaurant.Data.DataModels
{
    public class JoinTable
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public int MealId { get; set; }
    }
}
