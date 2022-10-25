using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : IdentityDbContext<ApiUser> //DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
        }
    }

    //public class HotelListingDbContextFactory : IDesignTimeDbContextFactory<HotelListingDbContext>
    //{
    //    public HotelListingDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = WebApplication.CreateBuilder(args);
    //        var configuration = builder.Configuration;
    //        var connectionString = builder.Configuration.GetConnectionString("HotelListingDbConnectionString3");

    //        var optionsBuilder = new DbContextOptionsBuilder<HotelListingDbContext>();
    //        optionsBuilder.UseSqlServer(connectionString);

    //        return new HotelListingDbContext(optionsBuilder.Options);
    //    }
    //}
}
