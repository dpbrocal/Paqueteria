using Paqueteria.Models.Dtos;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class DeliveryTest
    {
        public static DeliveryDto _dtoDelivery =>
            new()
            {
                Id = 5,
                CarrierId = 1,
                VehicleId = 4,
                Description = "Test description",
                DepartureDate = new System.DateTime()
            };
    }
}
