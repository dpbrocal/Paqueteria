using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models.Models;
using Paqueteria.Services.Common;
using System;

namespace Paqueteria.Api.Tests.Fixtures
{
    public partial class CommonDatabaseFixtureVehicle : IDisposable
    {
        private DbContextOptions<DBContext> _dbContextOptions;
        public DBContext context;
        public IMapper mapper;

        public CommonDatabaseFixtureVehicle()
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

            SeedVehicle();
        }

        public void SeedVehicle()
        {

            context.Vehicles.Add(new Vehicle
            {
                Id = 21,
                CarNumber = "1111ABC"
            });

            context.Vehicles.Add(new Vehicle
            {
                Id = 22,
                CarNumber = "2222DFG"
            });

            context.Vehicles.Add(new Vehicle
            {
                Id = 23,
                CarNumber = "3333HJK"
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
