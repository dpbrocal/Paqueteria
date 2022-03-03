
using System.Collections.Generic;

namespace Paqueteria.Models.Models
{
    public class Carrier : User
    {
        public string Licence { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
