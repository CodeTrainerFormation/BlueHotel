using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class BlueContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public BlueContext()
            : base()
        {
        }

        public BlueContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=BlueDb; Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Address);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(b => b.Customer);

            //many-to-many
            modelBuilder.Entity<BookingRoom>()
                .HasKey(br => new { br.BookingId, br.RoomId });

            modelBuilder.Entity<Room>()
                .HasMany(r => r.BookingRooms)
                .WithOne(br => br.Room);

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.BookingRooms)
                .WithOne(br => br.Booking);

            base.OnModelCreating(modelBuilder);
        }
    }
}
