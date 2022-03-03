using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Paqueteria.Api.Controllers;
using Paqueteria.Api.Tests.Fixtures;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Common;
using Paqueteria.Services.ImplClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class CarrierTest : IClassFixture<CommonDatabaseFixtureCarrier>
    {
        private IMapper _mapper;
        private DBContext _context;
        private readonly CarrierService _service;
        private readonly Mock<ICRUDRepository<Carrier>> _repository;


        public CarrierTest(CommonDatabaseFixtureCarrier c)
        {
            _context = c.context;
            _mapper = c.mapper;
            _service = new CarrierService(_mapper, _context);
            _repository = new Mock<ICRUDRepository<Carrier>>();

        }

        [Fact]
        public void GetAll()
        {
            var deliveries = GetSampleCarrier();
            _repository.Setup(x => x.GetAll())
                       .Returns(GetSampleCarrier());

            var controller = new CarrierController(_service, _mapper);

            var result = controller.GetAll();

            Assert.Equal(deliveries.Count(), result.Count());
        }

        [Fact]
        public void Insert()
        {
            var carrier = _service.Insert(_dtoCarrier);
            Assert.NotNull(carrier);
            Assert.NotNull(_context.Set<Carrier>().Find(_dtoCarrier.Id));
        }

        [Fact]
        public void Delete()
        {
            _service.Delete(Convert.ToInt32(_dtoCarrier.Id));
            Assert.Null(_context.Set<Carrier>().Find(_dtoCarrier.Id));
        }

        private List<Carrier> GetSampleCarrier()
        {
            List<Carrier> output = new List<Carrier>
            {
                new Carrier
                {
                    Id = 22,
                    Email = "pruebaClient2@hotmail.com",
                    Name = "TestName2",
                    Surnames = "TestSurnames2",
                    NIF = "1245930L",
                    Tel = "163942012",
                    Licence = "230945P"
                },
                new Carrier
                {
                    Id = 23,
                    Email = "pruebaClient2@hotmail.com",
                    Name = "TestName2",
                    Surnames = "TestSurnames2",
                    NIF = "1245930L",
                    Tel = "163942012",
                    Licence = "230945P"
                },
                new Carrier
                {
                    Id = 24,
                    Email = "pruebaClient2@hotmail.com",
                    Name = "TestName2",
                    Surnames = "TestSurnames2",
                    NIF = "1245930L",
                    Tel = "163942012",
                    Licence = "230945P"
                }
            };

            return output;
        }


    }
}
