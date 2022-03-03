using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Services.ImplClasses
{
    public class DeliveryService : IDeliveryService
    {
        private readonly DeliveryRepository<Delivery> _deliveryRepository;
        private readonly IMapper _mapper;
        private DBContext _context;

        public DeliveryService(IMapper mapper, DBContext context)
        {
            _context = context;
            _deliveryRepository = new DeliveryRepository<Delivery>(_context);
            _mapper = mapper;
        }

        public DeliveryDto Get(int id)
        {
            Delivery item = _deliveryRepository.Get(id);
            return _mapper.Map<DeliveryDto>(item);
        }

        public IEnumerable<Delivery> GetAll()
        {
            return _deliveryRepository.GetAll();
        }

        public DeliveryDto Insert(DeliveryDto item)
        {
            _deliveryRepository.Add(_mapper.Map<Delivery>(item));
            return item;
        }

        public DeliveryDto Update(DeliveryDto item)
        {
            _deliveryRepository.Update(_mapper.Map<Delivery>(item));
            return item;
        }

        public void Delete(int id)
        {
            _deliveryRepository.Delete(id);
        }
    }
}
