using Paqueteria.Models.Dtos;
using System;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class LocationTest
    {
        public static LocationHistoryDto _dtoLocation =>
            new()
            {
                Id = 2,
                Date = DateTime.Now,
                XCoord = 34,
                YCoord = 22,
                VehicleId = 1
            };
    }
}
