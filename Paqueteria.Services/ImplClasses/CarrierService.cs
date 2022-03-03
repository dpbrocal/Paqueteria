using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Services.ImplClasses
{
    public class CarrierService : ICarrierService
    {
        private readonly CarrierRepository<Carrier> _carrierRepository;
        private readonly IMapper _mapper;
        private DBContext _context;

        public CarrierService(IMapper mapper, DBContext context)
        {
            _context = context;
            _carrierRepository = new CarrierRepository<Carrier>(_context);
            _mapper = mapper;
        }

        public CarrierDto Get(int id)
        {
            Carrier item = _carrierRepository.Get(id);
            return _mapper.Map<CarrierDto>(item);
        }

        public IEnumerable<Carrier> GetAll()
        {
            return _carrierRepository.GetAll();
        }

        public CarrierRegisterDto Update(CarrierRegisterDto item)
        {
            _carrierRepository.Update(_mapper.Map<Carrier>(item));
            item.Password = null;
            return item;
        }

        public void Delete(int id)
        {
            _carrierRepository.Delete(id);
        }

        public LoginRequestDto FindByUsername(string username)
        {
            return _carrierRepository.FindByUsername(username);
        }

        public CarrierRegisterDto Register(CarrierRegisterDto item)
        {
            _carrierRepository.Add(_mapper.Map<Carrier>(item));
            item.Password = null;

            return item;
        }
    }
}
