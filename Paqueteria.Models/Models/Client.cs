
using System.Collections.Generic;

namespace Paqueteria.Models.Models
{
    public class Client : User
    {
        public string NumClient { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
