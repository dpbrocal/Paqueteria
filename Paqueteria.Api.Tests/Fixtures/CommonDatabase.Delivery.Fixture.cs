using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models.Models;
using Paqueteria.Services.Common;
using System;

namespace Paqueteria.Api.Tests.Fixtures
{
    public partial class CommonDatabaseFixtureDelivery : IDisposable
    {
        private DbContextOptions<DBContext> _dbContextOptions;
        public DBContext context;
        public IMapper mapper;

        public CommonDatabaseFixtureDelivery()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new DBContext(_dbContextOptions);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            mapper = mockMapper.CreateMapper();

            SeedDelivery();
        }

        public void SeedDelivery()
        {
            context.Set<Carrier>().Add(new Carrier
            {
                Id = 10,
                Email = "prueba@hotmail.com",
                Name = "ClientName",
                Surnames = "ClientSurnames",
                NIF = "1245930L",
                Tel = "163942012",
                Licence = "licencia01"
            });

            context.Set<Client>().Add(new Client
            {
                Id = 11,
                Email = "pruebaClient@hotmail.com",
                Name = "ClientName",
                Surnames = "ClientSurNames",
                NIF = "1245930L",
                Tel = "163942012",
                NumClient = "23823p"
            });

            context.Vehicles.Add(new Vehicle
            {
                Id = 4,
                CarNumber = "0000AAA"
            });

            context.Orders.Add(new Order
            {
                Id = 1,
                Address = "Address",
                Charged = true,
                ClientId = 11,
                DeliveryId = 1,
                Content = "Test order",
                Price = 10.3M,
                Weight = 20.5M
            });

            context.Deliveries.Add(new Delivery
            {
                Id = 22,
                Description = "Test description",
                CarrierId = 10,
                VehicleId = 4,
                DepartureDate = new System.DateTime()

            });

            context.Deliveries.Add(new Delivery
            {
                Id = 23,
                Description = "Test description",
                CarrierId = 10,
                VehicleId = 4,
                DepartureDate = new System.DateTime(),


            });

            context.Deliveries.Add(new Delivery
            {
                Id = 24,
                Description = "Test description",
                CarrierId = 10,
                VehicleId = 4,
                DepartureDate = new System.DateTime()

            });

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
