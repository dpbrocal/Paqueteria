using System;
using System.Collections.Generic;

namespace Paqueteria.Models.Models
{
    public class Delivery
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime DepartureDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
        public virtual Carrier Carrier { get; set; }
        public long CarrierId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
