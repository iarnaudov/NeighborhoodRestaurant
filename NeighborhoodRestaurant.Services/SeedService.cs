using NeighborhoodRestaurant.Data;
using NeighborhoodRestaurant.Data.Enums;
using NeighborhoodRestaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NeighborhoodRestaurant.Services
{
    public static class SeedService
    {
        public static void SeedData(RestaurantDbContext dbContext)
        {
            var meals = new List<Meal>()
            {
             new Meal()
             {
                 Name = "Salmon with Veggies",
                 MealType = MealType.MainCourse,
                 PictureUrl = "https://image.shutterstock.com/image-photo/macro-shot-grilled-chicken-fillet-260nw-1495898873.jpg",
             },
             new Meal()
             {
                 Name = "Tournedo of Beef",
                 MealType = MealType.MainCourse,
                 PictureUrl = "https://i.pinimg.com/originals/9f/1a/d7/9f1ad7ed5a56b4f7d4b1fe4832451e16.jpg",
             },
             new Meal()
             {
                 Name = "Duck with sausa",
                 MealType = MealType.MainCourse,
                 PictureUrl = "https://i.ytimg.com/vi/mV_TmLc_2CQ/maxresdefault.jpg",
             },
             new Meal()
             {
                 Name = "Roast Pork",
                 MealType = MealType.MainCourse,
                 PictureUrl = "https://img.delicious.com.au/qDM2WBAw/w759-h506-q80-cfill/del/2015/10/roast-pork-with-apple-and-apricot-stuffing-19303-2.jpg",
             },
             new Meal()
             {
                 Name = "Lamp Racks",
                 MealType = MealType.MainCourse,
                 PictureUrl = "https://img.delicious.com.au/CET1ewko/w759-h506-q80-cfill/del/2015/10/coriander-and-maple-syrup-lamb-racks-15848-2.jpg",
             },
             new Meal()
             {
                 Name = "Hand-cut pasta carbonara",
                 MealType = MealType.MainCourse,
                 PictureUrl = "https://img.delicious.com.au/nYfQCEmN/w759-h506-q80-cfill/del/2015/10/hand-cut-pasta-with-proscuitto-asparagus-and-baby-cos-15778-2.jpg",
             },
             new Meal()
             {
                 Name = "Sweet potato with mayonaise",
                 MealType = MealType.Appetizer,
                 PictureUrl = "https://kalynskitchen.com/wp-content/uploads/2014/12/2-650-sweet-potato-appetizer-bites-9-kalynskitchen.jpg",
             },
             new Meal()
             {
                 Name = "Proshuto cracker",
                 MealType = MealType.Appetizer,
                 PictureUrl = "https://www.familyfreshmeals.com/wp-content/uploads/2018/11/Easy-Creamy-Prosciutto-Cracker-Appetizer-Recipe-Family-Fresh-Meals-500x500.jpg",
             },
             new Meal()
             {
                 Name = "Avocado Shrimp Cucumber",
                 MealType = MealType.Appetizer,
                 PictureUrl = "https://www.yummyhealthyeasy.com/wp-content/uploads/2018/06/Low-Carb-Avocado-Shrimp-Cucumber-Appetizer-Square.jpg",
             },
             new Meal()
             {
                 Name = "Smoked salmon with avocado",
                 MealType = MealType.Appetizer,
                 PictureUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fcdn-image.myrecipes.com%2Fsites%2Fdefault%2Ffiles%2Fstyles%2Fmedium_2x%2Fpublic%2Ffingerling-potatoes-avocado-smoked-salmon-sl.jpg%3Fitok%3DGWQr7Sk4",
             },
             new Meal()
             {
                 Name = "Cranberry appetizer",
                 MealType = MealType.Appetizer,
                 PictureUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fcdn-image.myrecipes.com%2Fsites%2Fdefault%2Ffiles%2Fstyles%2Fmedium_2x%2Fpublic%2Ffingerling-potatoes-avocado-smoked-salmon-sl.jpg%3Fitok%3DGWQr7Sk4",
             },
             new Meal()
             {
                 Name = "Chocolate balls",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-oreo-truffles-078-1544222424.jpg",
             },
             new Meal()
             {
                 Name = "Eclers",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://images.immediate.co.uk/production/volatile/sites/2/2017/12/xmas-Cover-17v5-54a9395.jpg?quality=90&resize=768%2C574",
             },
             new Meal()
             {
                 Name = "Mixed Berries",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://assets.kraftfoods.com/recipe_images/opendeploy/204595_640x428.jpg",
             },
             new Meal()
             {
                 Name = "OREO Cake",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://img.buzzfeed.com/thumbnailer-prod-us-east-1/video-api/assets/157394.jpg",
             },
             new Meal()
             {
                 Name = "Tiramisu",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://images.immediate.co.uk/production/volatile/sites/2/2019/07/Tiramisu-d68a628.jpg?quality=45&resize=768,574",
             },
             new Meal()
             {
                 Name = "Molten Chocolate Cake",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F9%2F2020%2F02%2Fmolten-chocolate-cake-FT-RECIPE0220.jpg",
             },
             new Meal()
             {
                 Name = "Your type of cake",
                 MealType = MealType.Dessert,
                 PictureUrl = "https://img.bestrecipes.com.au/BPQkMohQ/w643-h428-cfill-q90/br/2018/06/malteser-christmas-cake-recipe-523065-1.jpg",
             },
            };

            dbContext.AddRange(meals);
            dbContext.SaveChanges();
        }
    }
}
