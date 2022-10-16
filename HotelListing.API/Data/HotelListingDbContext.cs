﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                   new Country
                   {
                       Id = 1,
                       Name = "Jamaica",
                       ShortName = "JM"
                   },
                   new Country
                   {
                       Id = 2,
                       Name = "Bahamas",
                       ShortName = "BS"
                   },
                   new Country
                   {
                       Id = 3,
                       Name = "Cayman Island",
                       ShortName = "CI"
                   }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Confort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Palldium",
                    Address = "Nassua",
                    CountryId = 2,
                    Rating = 4
                }

                );
        }
    }

    public class HotelListingDbContextFactory : IDesignTimeDbContextFactory<HotelListingDbContext>
    {
        public HotelListingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelListingDbContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-D32HSJG2;Database=HotelListingAPIDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new HotelListingDbContext(optionsBuilder.Options);
        }
    }
}
