using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Data.DTOs;
using NeighborhoodRestaurant.Data.Enums;
using System;
using System.Collections.Generic;

namespace NeighborhoodRestaurant.Services
{
    public class DateService
    {
        private readonly RestaurantDbContext databaseCtx;
        private readonly OrderService orderService;

        public DateService(RestaurantDbContext databaseContext)
        {
            this.databaseCtx = databaseContext;
            this.orderService = new OrderService(databaseContext);
        }

        public ICollection<WeekDaysAvailability> GetCustomerOrdersForTheWeek(string userId)
        {
            string[] weekDays = this.GetFullWeekDates();
            List<WeekDaysAvailability> weekDaysAvailability = new List<WeekDaysAvailability>();

            for (int i = 0; i < 7; i++)
            {
                weekDaysAvailability.Add(new WeekDaysAvailability()
                {
                    WeekDay = (DayOfWeek)i,
                    WeekDayEnumValue = i,
                    DateString = weekDays[i],
                    AlreadyOrdered = this.orderService.UserHasOrderForTheDay(userId, (DayOfWeek)i )
                });
            };

            weekDaysAvailability.Add(weekDaysAvailability[0]);
            weekDaysAvailability.Remove(weekDaysAvailability[0]);

            return weekDaysAvailability;
        }


        public string[] GetFullWeekDates()
        {
            string monday = GetNextWeekday(DateTime.Today, DayOfWeek.Monday);
            string tuesday = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Tuesday);
            string wednesday = GetNextWeekday(DateTime.Today.AddDays(2), DayOfWeek.Wednesday);
            string thursday = GetNextWeekday(DateTime.Today.AddDays(3), DayOfWeek.Thursday);
            string friday = GetNextWeekday(DateTime.Today.AddDays(4), DayOfWeek.Friday);
            string saturday = GetNextWeekday(DateTime.Today.AddDays(5), DayOfWeek.Saturday);
            string sunday = GetNextWeekday(DateTime.Today.AddDays(6), DayOfWeek.Sunday);
            string[] weekDates = new string[] { sunday, monday, tuesday, wednesday, thursday, friday, saturday };
            return weekDates;
        }

        private string GetNextWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd).ToString("dd.MM.yyyy");
        }
    }
}
