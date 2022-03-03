using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models.Models;
using Paqueteria.Services.Common;
using System;

namespace Paqueteria.Api.Tests.Fixtures
{
    public partial class CommonDatabaseFixtureCarrier : IDisposable
    {
        private DbContextOptions<DBContext> _dbContextOptions;
        public DBContext context;
        public IMapper mapper;

        public CommonDatabaseFixtureCarrier()
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

            SeedCarrier();
        }

        public void SeedCarrier()
        {
            context.Set<Carrier>().Add(new Carrier
            {
                Id = 22,
                Email = "pruebaClient2@hotmail.com",
                Name = "TestName2",
                Surnames = "TestSurnames2",
                NIF = "1245930L",
                Tel = "163942012",
                Licence = "230945P"
            });

            context.Set<Carrier>().Add(new Carrier
            {
                Id = 23,
                Email = "pruebaClient2@hotmail.com",
                Name = "TestName2",
                Surnames = "TestSurnames2",
                NIF = "1245930L",
                Tel = "163942012",
                Licence = "230945P"
            });


            context.Set<Carrier>().Add(new Carrier
            {
                Id = 24,
                Email = "pruebaClient2@hotmail.com",
                Name = "TestName2",
                Surnames = "TestSurnames2",
                NIF = "1245930L",
                Tel = "163942012",
                Licence = "230945P"
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
