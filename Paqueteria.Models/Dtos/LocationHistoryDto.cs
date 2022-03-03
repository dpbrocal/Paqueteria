
using System;

namespace Paqueteria.Models.Dtos
{
    public class LocationHistoryDto
    {
        public long Id { get; set; }
        public long XCoord { get; set; }
        public long YCoord { get; set; }
        public DateTime Date { get; set; }

        public long VehicleId { get; set; }
    }
}
