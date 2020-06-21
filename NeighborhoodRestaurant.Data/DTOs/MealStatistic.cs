using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodRestaurant.Data.DTOs
{
    public class MealStatistic
    {
        public string MealName { get; set; }
        public int Count { get; set; }
        public List<int> UserIds { get; set; }
    }
}
