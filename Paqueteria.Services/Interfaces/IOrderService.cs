
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using System.Collections.Generic;

namespace Paqueteria.Services.Interfaces
{
    public interface IOrderService
    {
        public OrderDto Get(int id);
        public IEnumerable<Order> GetAll();
        public OrderDto Insert(OrderDto item);
        public OrderDto Update(OrderDto item);
        public void Delete(int id);
    }
}
