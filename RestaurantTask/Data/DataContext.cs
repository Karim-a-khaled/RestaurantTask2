using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantTask.Models;

namespace RestaurantTask.Data
{
    public class DataContext : IdentityDbContext<AppUser, IdentityRole, string,
IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=RestaurantTask;Encrypt=False;Integrated Security=SSPI";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var restaurants = modelBuilder.Entity<Restaurant>();
            var tables = modelBuilder.Entity<RestaurantTable>();
            var reservations = modelBuilder.Entity<Reservation>();
            var users = modelBuilder.Entity<AppUser>();
            //var tableTypes = modelBuilder.Entity<TableType>();

            tables.Property(rt => rt.Price).HasColumnType("decimal(5,2)");

            restaurants.HasMany(r => r.RestaurantTables).WithOne(t => t.Restaurant);
            tables.HasMany(t => t.Reservations).WithOne(r => r.RestaurantTable);
            users.HasMany(u => u.Reservations).WithOne(r => r.User);
            //tableTypes.HasOne(tt => tt.RestaurantTable).WithOne(t => t.TableType).HasForeignKey<RestaurantTable>("TableType_Id");
        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        //public DbSet<TableType> TableTypes { get; set; }
    }
    
}
