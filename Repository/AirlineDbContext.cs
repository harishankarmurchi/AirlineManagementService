using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.DBModels;

namespace Repository
{
    public class AirlineDbContext:DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(x => x.FromPlace)
                .WithMany(x => x.FromFlights)
                .HasForeignKey(x => x.FromPlaceId);

            modelBuilder.Entity<Flight>()
                .HasOne(x => x.ToPlace)
                .WithMany(x => x.ToFlights)
                .HasForeignKey(x => x.ToPlaceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<FlightSeats> Seats { get; set; }
        public DbSet<Place> Places { get; set; }


    }
}