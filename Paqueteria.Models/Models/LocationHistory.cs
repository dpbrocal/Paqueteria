using System;

namespace Paqueteria.Models.Models
{
    public class LocationHistory
    {
        public long Id { get; set; }
        public long XCoord { get; set; }
        public long YCoord { get; set; }
        public DateTime Date { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
    }
}
