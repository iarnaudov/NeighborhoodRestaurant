using NeighborhoodRestaurant.Data.DTOs;
using NeighborhoodRestaurant.Data.Models;
using System;
using System.Collections.Generic;

namespace NeighborhoodRestaurant.Web.ViewModels
{
    public class SelectMenuViewModel
    {
        public ICollection<WeekDaysAvailability> WeekDays { get; set; }
        public ICollection<Meal> Appetizers { get; set; }
        public ICollection<Meal> MainCourses { get; set; }
        public ICollection<Meal> Desserts { get; set; }
    }
}
