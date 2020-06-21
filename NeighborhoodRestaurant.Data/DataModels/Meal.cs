using NeighborhoodRestaurant.Data.Enums;
using System.Collections.Generic;

namespace NeighborhoodRestaurant.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<MealOrder> MealOrders { get; set; }
    }
}
