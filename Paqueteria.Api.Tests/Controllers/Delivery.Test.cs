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
    public partial class DeliveryTest : IClassFixture<CommonDatabaseFixtureDelivery>
    {
        private IMapper _mapper;
        private DBContext _context;
        private readonly DeliveryService _service;
        private readonly Mock<ICRUDRepository<Delivery>> _repository;

        public DeliveryTest(CommonDatabaseFixtureDelivery d)
        {
            _context = d.context;
            _mapper = d.mapper;
            _service = new DeliveryService(_mapper, _context);
            _repository = new Mock<ICRUDRepository<Delivery>>();
        }

        [Fact]
        public void GetAll()
        {
            var deliveries = GetSampleDelivery();
            _repository.Setup(x => x.GetAll())
                       .Returns(GetSampleDelivery());

            var controller = new DeliveryController(_service, _mapper);

            var result = controller.GetAll();

            Assert.Equal(deliveries.Count(), result.Count());
        }

        [Fact]
        public void Insert()
        {
            var delivery = _service.Insert(_dtoDelivery);
           Assert.NotNull(delivery);
            Assert.NotNull(_context.Deliveries.Find(_dtoDelivery.Id));
        }

        [Fact]
        public void Delete()
        {
            _service.Delete(Convert.ToInt32(_dtoDelivery.Id));
            Assert.Null(_context.Deliveries.Find(_dtoDelivery.Id));
        }

        private List<Delivery> GetSampleDelivery()
        {
            List<Delivery> output = new List<Delivery>
            {
                new Delivery
                {
                    Id = 22,
                    CarrierId = 1,
                    VehicleId = 4,
                    Description = "Test description",
                    DepartureDate = new System.DateTime()
                },
                new Delivery
                {
                    Id = 23,
                    CarrierId = 1,
                    VehicleId = 4,
                    Description = "Test description",
                    DepartureDate = new System.DateTime()
                },
                new Delivery
                {
                    Id = 24,
                    CarrierId = 1,
                    VehicleId = 4,
                    Description = "Test description",
                    DepartureDate = new System.DateTime()
                }
            };

            return output;
        }


    }
}
