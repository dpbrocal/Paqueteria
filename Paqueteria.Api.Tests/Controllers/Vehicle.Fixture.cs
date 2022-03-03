using Paqueteria.Models.Dtos;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class VehicleTest
    {
        public static VehicleDto _dtoVehicle =>
            new()
            {
                Id = 32,
                CarNumber = "0000MBB"
            };
    }
}
