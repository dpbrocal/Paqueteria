
namespace Paqueteria.Models.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Address { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public bool Charged { get; set; }

        public virtual Client Client { get; set; }
        public long ClientId { get; set; }
        public virtual Delivery Delivery { get; set; }
        public long DeliveryId { get; set; }
    }
}
