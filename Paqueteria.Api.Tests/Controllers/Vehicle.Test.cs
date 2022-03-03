using AutoMapper;
using Moq;
using Paqueteria.Api.Controllers;
using Paqueteria.Api.Tests.Fixtures;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Services.ImplClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class VehicleTest : IClassFixture<CommonDatabaseFixtureVehicle>
    {
        private IMapper _mapper;
        private DBContext _context;
        private readonly VehicleService _service;
        private readonly Mock<ICRUDRepository<Vehicle>> _repository;

        public VehicleTest(CommonDatabaseFixtureVehicle v)
        {
            _mapper = v.mapper;
            _context = v.context;
            _service = new VehicleService(_mapper, _context);
            _repository = new Mock<ICRUDRepository<Vehicle>>();
        }
        
        [Fact]
        public void GetAll()
        {
            var vehicles = GetSampleVehicle();
            _repository.Setup(x => x.GetAll())
                       .Returns(GetSampleVehicle());

            var controller = new VehicleController(_service, _mapper);

            var result = controller.GetAll();

            Assert.Equal(vehicles.Count(), result.Count());
        }

        [Fact]
        public void Insert()
        {
            var vehicle = _service.Insert(_dtoVehicle);
            Assert.NotNull(vehicle);
            Assert.NotNull(_context.Vehicles.Find(_dtoVehicle.Id));
        }

        [Fact]
        public void Delete()
        {
            _service.Delete(Convert.ToInt32(_dtoVehicle.Id));
            Assert.Null(_context.Vehicles.Find(_dtoVehicle.Id));
        }

        private List<Vehicle> GetSampleVehicle()
        {
            List<Vehicle> output = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 21,
                    CarNumber = "1111ABC"
                },
                new Vehicle
                {
                    Id = 22,
                    CarNumber = "2222DFG"
                },
                new Vehicle
                {
                    Id = 23,
                    CarNumber = "3333HJK"
                }
            };

            return output;
        }
    }
}
