using System;

namespace Paqueteria.Models.Dtos
{
    public class DeliveryDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime DepartureDate { get; set; }

        public long VehicleId { get; set; }
        public long CarrierId { get; set; }
    }
}
