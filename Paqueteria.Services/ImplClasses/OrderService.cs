using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Services.ImplClasses
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private DBContext _context;

        public OrderService(IMapper mapper, DBContext context)
        {
            _context = context;
            _orderRepository = new OrderRepository<Order>(_context);
            _mapper = mapper;
        }

        public OrderDto Get(int id)
        {
            Order item = _orderRepository.Get(id);
            return _mapper.Map<OrderDto>(item);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public OrderDto Insert(OrderDto item)
        {
            _orderRepository.Add(_mapper.Map<Order>(item));
            return item;
        }

        public OrderDto Update(OrderDto item)
        {
            _orderRepository.Update(_mapper.Map<Order>(item));
            return item;
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }
    }
}
