using NeighborhoodRestaurant.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborhoodRestaurant.Data.DTOs
{
    public class WeekDaysAvailability
    {
        public DayOfWeek WeekDay { get; set; }
        public int WeekDayEnumValue { get; set; }
        public string DateString { get; set; }
        public bool AlreadyOrdered { get; set; }
    }
}
