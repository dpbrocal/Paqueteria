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
    public partial class ClientTest : IClassFixture<CommonDatabaseFixtureClient>
    {
        private IMapper _mapper;
        private DBContext _context;
        private readonly ClientService _service;
        private readonly Mock<ICRUDRepository<Client>> _repository;


        public ClientTest(CommonDatabaseFixtureClient c)
        {
            _context = c.context;
            _mapper = c.mapper;
            _service = new ClientService(_mapper, _context);
            _repository = new Mock<ICRUDRepository<Client>>();
        }

        [Fact]
        public void GetAll()
        {
            var deliveries = GetSampleClient();
            _repository.Setup(x => x.GetAll())
                       .Returns(GetSampleClient());

            var controller = new ClientController(_service, _mapper);

            var result = controller.GetAll();

            Assert.Equal(deliveries.Count(), result.Count());
        }

        [Fact]
        public void Insert()
        {
            var client = _service.Insert(_dtoClient);
            Assert.NotNull(client);
            Assert.NotNull(_context.Set<Client>().Find(_dtoClient.Id));
        }

        [Fact]
        public void Delete()
        {
            _service.Delete(Convert.ToInt32(_dtoClient.Id));
            Assert.Null(_context.Set<Client>().Find(_dtoClient.Id));
        }

        private List<Client> GetSampleClient()
        {
            List<Client> output = new List<Client>
            {
                new Client
                {
                    Id = 22,
                    Email = "pruebaClient2@hotmail.com",
                    Name = "TestName2",
                    Surnames = "TestSurnames2",
                    NIF = "1245930L",
                    Tel = "163942012",
                    NumClient = "23823p"
                },
                new Client
                {
                    Id = 23,
                    Email = "pruebaClient2@hotmail.com",
                    Name = "TestName2",
                    Surnames = "TestSurnames2",
                    NIF = "1245930L",
                    Tel = "163942012",
                    NumClient = "23823p"
                },
                new Client
                {
                    Id = 24,
                    Email = "pruebaClient2@hotmail.com",
                    Name = "TestName2",
                    Surnames = "TestSurnames2",
                    NIF = "1245930L",
                    Tel = "163942012",
                    NumClient = "23823p"
                }
            };

            return output;
        }


    }
}
