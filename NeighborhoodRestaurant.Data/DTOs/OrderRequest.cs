using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborhoodRestaurant.Data.DTOs
{
    public class OrderRequest
    {
        public int WeekDay { get; set; }
        public ICollection<int> Meals { get; set; }
    }
}
