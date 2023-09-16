using CityInfoAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Data
{
    public class CPDbContext : DbContext
    {
        public DbSet<City> cities { get; set; }
        public DbSet <PointOfInterest> pointOfInterests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public CPDbContext(DbContextOptions<CPDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
               new City("New York City")
               {
                   Id = 1,
                   Description = "The one with that big park."
               },
               new City("Antwerp")
               {
                   Id = 2,
                   Description = "The one with the cathedral that was never really finished."
               },
               new City("Paris")
               {
                   Id = 3,
                   Description = "The one with that big tower."
               });

            modelBuilder.Entity<PointOfInterest>()
             .HasData(
               new PointOfInterest("Central Park")
               {
                   Id = 1,
                   cityId = 1,
                   Description = "The most visited urban park in the United States."
               },
               new PointOfInterest("Empire State Building")
               {
                   Id = 2,
                   cityId = 1,
                   Description = "A 102-story skyscraper located in Midtown Manhattan."
               },
                 new PointOfInterest("Cathedral")
                 {
                     Id = 3,
                     cityId = 2,
                     Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                 },
               new PointOfInterest("Antwerp Central Station")
               {
                   Id = 4,
                   cityId = 2,
                   Description = "The the finest example of railway architecture in Belgium."
               },
               new PointOfInterest("Eiffel Tower")
               {
                   Id = 5,
                   cityId = 3,
                   Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
               },
               new PointOfInterest("The Louvre")
               {
                   Id = 6,
                   cityId = 3,
                   Description = "The world's largest museum."
               }
               );
       



            // Specify table names explicitly
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<PointOfInterest>().ToTable("PointOfInterests");
        }

    }
}
