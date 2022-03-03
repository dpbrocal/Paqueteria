using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Common;
using Paqueteria.Services.ImplClasses;
using Xunit;
using System;
using Paqueteria.Api.Tests.Fixtures;
using Moq;
using Paqueteria.Repositories.Common;
using System.Collections.Generic;
using Paqueteria.Api.Controllers;
using System.Linq;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class LocationTest : IClassFixture<CommonDatabaseFixtureLocation>
    {
        private IMapper _mapper;
        private DBContext _context;
        private readonly LocationHistoryService _service;
        private readonly Mock<ICRUDRepository<LocationHistory>> _repository;

        public LocationTest(CommonDatabaseFixtureLocation l)
        {
            _context = l.context;
            _mapper = l.mapper;
            _service = new LocationHistoryService(_mapper, _context);
            _repository = new Mock<ICRUDRepository<LocationHistory>>();
        }

        [Fact]
        public void GetAll()
        {
            var deliveries = GetSampleLocationHistory();
            _repository.Setup(x => x.GetAll())
                       .Returns(GetSampleLocationHistory());

            var controller = new LocationHistoryController(_service, _mapper);

            var result = controller.GetAll();

            Assert.Equal(deliveries.Count(), result.Count());
        }

        [Fact]
        public void Insert()
        {
            var location = _service.Insert(_dtoLocation);
            Assert.NotNull(location);
            Assert.NotNull(_context.LocationHistory.Find(_dtoLocation.Id));
        }

        [Fact]
        public void Delete()
        {
            _service.Delete(Convert.ToInt32(_dtoLocation.Id));
            Assert.Null(_context.LocationHistory.Find(_dtoLocation.Id));
        }

        private List<LocationHistory> GetSampleLocationHistory()
        {
            List<LocationHistory> output = new List<LocationHistory>
            {
                new LocationHistory
                {
                    Id = 1,
                    Date = DateTime.Now,
                    XCoord = 34,
                    YCoord = 22,
                    VehicleId = 1

                },
                new LocationHistory
                {
                    Id = 10,
                    Date = DateTime.Now,
                    XCoord = 44,
                    YCoord = 56,
                    VehicleId = 1
                },
                new LocationHistory
                {
                    Id = 11,
                    Date = DateTime.Now,
                    XCoord = 66,
                    YCoord = 78,
                    VehicleId = 1
                }
        };

            return output;
        }


    }
}
