using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models.Models;
using Paqueteria.Services.Common;
using System;

namespace Paqueteria.Api.Tests.Fixtures
{
    public partial class CommonDatabaseFixtureLocation : IDisposable
    {
        private DbContextOptions<DBContext> _dbContextOptions;
        public DBContext context;
        public IMapper mapper;

        public CommonDatabaseFixtureLocation()
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

            SeedLocation();

        }

        public void SeedLocation()
        {
            context.Vehicles.Add(new Vehicle
            {
                Id = 1,
                CarNumber = "0000AAA"
            });

            context.LocationHistory.Add(new LocationHistory
            {
                Id = 1,
                Date = DateTime.Now,
                XCoord = 34,
                YCoord = 22,
                VehicleId = 1
            });

            context.LocationHistory.Add(new LocationHistory
            {
                Id = 10,
                Date = DateTime.Now,
                XCoord = 44,
                YCoord = 56,
                VehicleId = 1
            });

            context.LocationHistory.Add(new LocationHistory
            {
                Id = 11,
                Date = DateTime.Now,
                XCoord = 66,
                YCoord = 78,
                VehicleId = 1
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
