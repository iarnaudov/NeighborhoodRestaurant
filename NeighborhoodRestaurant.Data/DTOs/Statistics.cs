using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodRestaurant.Data.DTOs
{
    class Statistics
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<MealStatistic> Meals { get; set; }
    }
}
