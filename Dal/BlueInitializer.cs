using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DomainModel;

namespace Dal
{
    public static class BlueInitializer
    {
        public static void Initialize(this BlueContext context, bool dropAlways = false)
        {
            //To drop database or not
            if (dropAlways)
                context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            //if db has been already seeded
            if (context.Hotels.Any())
                return;

            var addresses = new List<Address>()
            {
                //hotels
                new Address()
                {
                    Street = "14 rue de Wagram",
                    ZipCode = "75000",
                    City = "Paris",
                    Country = "France",
                    Email = "14wagram@bluehotel.com",
                    Phone = "+33100112233",
                    Latitude = 48.876673,
                    Longitude = 2.297336,
                },
                new Address()
                {
                    Street = "Calle de Monte Igueldo",
                    ZipCode = "20001",
                    City = "San Sebastian",
                    Country = "Espagne",
                    Email = "monteigueldo@bluehotel.com",
                    Phone = "+33100112234",
                    Latitude = 48.876673,
                    Longitude = 2.297336,
                },
                new Address()
                {
                    Street = "4, rue du marché aux fleurs",
                    ZipCode = "06000",
                    City = "Nice",
                    Country = "France",
                    Email = "nice@bluehotel.com",
                    Phone = "+33100112234",
                    Latitude = 48.876673,
                    Longitude = 2.297336,
                },
                // customer
                new Address()
                {
                    Street = "sacred heart street",
                    ZipCode = "00000",
                    City = "Los Angeles",
                    Country = "USA",
                    Email = "john@dorian.com",
                    Phone = "+555001111",
                    Latitude = 48.876673,
                    Longitude = 2.297336,
                },
                new Address()
                {
                    Street = "1, place bellecour",
                    ZipCode = "69001",
                    City = "Lyon",
                    Country = "France",
                    Email = "perry-cox@gmail.lan",
                    Phone = "+33610101010",
                    Latitude = 48.876673,
                    Longitude = 2.297336,
                },
                new Address()
                {
                    Street = "1, place de la pyramide",
                    ZipCode = "75100",
                    City = "Paris",
                    Country = "France",
                    Email = "ted@ib.cegos.fr",
                    Phone = "+177223355",
                    Latitude = 48.876673,
                    Longitude = 2.297336,
                },
            };

            var rooms = new List<Room>()
            {
                //hotel1
                new Room()
                {
                    Name = "Confort",
                    Category = "Chambre Confort, tv, clim",
                    Floor = 1,
                },
                new Room()
                {
                    Name = "Confort",
                    Category = "Chambre Confort, tv, clim",
                    Floor = 1,
                },
                new Room()
                {
                    Name = "Confort",
                    Category = "Chambre Confort, tv, clim",
                    Floor = 1,
                },
                //hotel2
                new Room()
                {
                    Name = "Confort",
                    Category = "Chambre Confort, tv, clim",
                    Floor = 1,
                },
                new Room()
                {
                    Name = "Confort",
                    Category = "Chambre Confort, tv, clim",
                    Floor = 1,
                },
                new Room()
                {
                    Name = "Prestige",
                    Category = "Chambre Prestige, nespresso, tv, clim",
                    Floor = 2,
                },
                //hotel3
                new Room()
                {
                    Name = "Prestige",
                    Category = "Chambre Prestige, nespresso, tv, clim",
                    Floor = 2,
                },
                new Room()
                {
                    Name = "Prestige",
                    Category = "Chambre Prestige, nespresso, tv, clim",
                    Floor = 2,
                },
                new Room()
                {
                    Name = "Suite luxe",
                    Category = "Suite de luxe, jacuzzi, nespresso, tv, clim",
                    Floor = 3,
                },
                new Room()
                {
                    Name = "Suite luxe",
                    Category = "Suite de luxe, jacuzzi, nespresso, tv, clim",
                    Floor = 3,
                },
            };

            var hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Name = "Blue Hotel Wagram",
                    Address = addresses[0],
                    Star = 2,
                    Rooms = rooms.GetRange(0, 3),
                },
                new Hotel()
                {
                    Name = "Dark Blue San Sebastian",
                    Address = addresses[1],
                    Star = 4,
                    Rooms = rooms.GetRange(3, 3),
                },
                new Hotel()
                {
                    Name = "Light Blue Nice",
                    Address = addresses[2],
                    Star = 1,
                    Rooms = rooms.GetRange(6, 4),
                },
            };

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FullName = "John Dorian",
                    DateOfBirth = new DateTime(1980, 10, 22),
                    Address = addresses[1],
                },
                new Customer()
                {
                    FullName = "Perry Cox",
                    DateOfBirth = new DateTime(1970, 05, 15),
                    Address = addresses[1],
                },
                new Customer()
                {
                    FullName = "Ted Mosby",
                    DateOfBirth = new DateTime(1978, 11, 12),
                    Address = addresses[1],
                },
            };

            var bookings = new List<Booking>()
            {
                new Booking()
                {
                    Created = DateTime.Now,
                    CheckIn = DateTime.Now.AddDays(2),
                    CheckOut = DateTime.Now.AddDays(4),
                    Price = 180,
                    IsPaid = true,
                    Customer = customers[0],
                },
                new Booking()
                {
                    Created = DateTime.Now,
                    CheckIn = DateTime.Now.AddDays(15),
                    CheckOut = DateTime.Now.AddDays(20),
                    Price = 450,
                    IsPaid = false,
                    Customer = customers[0],
                },
                new Booking()
                {
                    Created = DateTime.Now,
                    CheckIn = DateTime.Now.AddDays(5),
                    CheckOut = DateTime.Now.AddDays(6),
                    Price = 145,
                    IsPaid = false,
                    Customer = customers[1],
                },
            };

            var bookingRooms = new List<BookingRoom>()
            {
                new BookingRoom()
                {
                    Booking = bookings[0],
                    Room = rooms[0],
                },
                new BookingRoom()
                {
                    Booking = bookings[1],
                    Room = rooms[3],
                },
                new BookingRoom()
                {
                    Booking = bookings[2],
                    Room = rooms[6],
                },
            };

            context.Addresses.AddRange(addresses);
            context.Rooms.AddRange(rooms);
            context.Hotels.AddRange(hotels);
            context.Customers.AddRange(customers);
            context.Bookings.AddRange(bookings);
            context.BookingRooms.AddRange(bookingRooms);

            context.SaveChanges();
        }
    }
}
