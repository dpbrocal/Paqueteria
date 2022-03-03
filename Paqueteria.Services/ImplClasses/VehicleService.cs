using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Services.ImplClasses
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;
        private DBContext _context;

        public VehicleService(IMapper mapper, DBContext context)
        {
            _context = context;
            _vehicleRepository = new VehicleRepository<Vehicle>(_context);
            _mapper = mapper;
        }

        public VehicleDto Get(int id)
        {
            Vehicle item = _vehicleRepository.Get(id);
            return _mapper.Map<VehicleDto>(item);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicleRepository.GetAll();
        }

        public VehicleDto Insert(VehicleDto item)
        {
            _vehicleRepository.Add(_mapper.Map<Vehicle>(item));
            return item;
        }


        public VehicleDto Update(VehicleDto item)
        {
            _vehicleRepository.Update(_mapper.Map<Vehicle>(item));
            return item;
        }

        public void Delete(int id)
        {
            _vehicleRepository.Delete(id);
        }
    }
}
