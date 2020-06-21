using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodRestaurant.Data.DTOs
{
    public class MostWantedMeal
    {
        public string MealName { get; set; }
        public string PictureLink { get; set; }
        public int OrderCount { get; set; }
    }
}
