using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NeighborhoodRestaurant.Data.Models
{
    public class RestaurantCustomer : IdentityUser
    {

        [PersonalData]
        public string Firstname { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
    }
}
