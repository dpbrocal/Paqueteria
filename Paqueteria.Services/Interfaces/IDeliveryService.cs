
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using System.Collections.Generic;

namespace Paqueteria.Services.Interfaces
{
    public interface IDeliveryService
    {
        public DeliveryDto Get(int id);
        public IEnumerable<Delivery> GetAll();
        public DeliveryDto Insert(DeliveryDto item);
        public DeliveryDto Update(DeliveryDto item);
        public void Delete(int id);
    }
}
