using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeighborhoodRestaurant.Data.DataModels;
using NeighborhoodRestaurant.Data.Models;

namespace NeighborhoodRestaurant.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealOrder> MealOrders { get; set; }
        public DbSet<JoinTable> JoinTable { get; set; }
        public DbSet<ProperJoin> ProperJoinTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
 => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestaurantDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MealOrder>()
                .HasKey(mo => new { mo.MealId, mo.OrderId });
            modelBuilder.Entity<MealOrder>()
                .HasOne(mo => mo.Order)
                .WithMany(m => m.MealOrders)
                .HasForeignKey(mo => mo.OrderId);
            modelBuilder.Entity<MealOrder>()
                .HasOne(mo => mo.Meal)
                .WithMany(m => m.MealOrders)
                .HasForeignKey(mo => mo.MealId);
            modelBuilder.Entity<JoinTable>().HasNoKey();
            modelBuilder.Entity<ProperJoin>().HasNoKey();
        }
    }
}
