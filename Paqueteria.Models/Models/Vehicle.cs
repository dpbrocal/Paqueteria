using System.Collections.Generic;

namespace Paqueteria.Models.Models
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string CarNumber { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<LocationHistory> LocationHistory { get; set; }
    }
}
