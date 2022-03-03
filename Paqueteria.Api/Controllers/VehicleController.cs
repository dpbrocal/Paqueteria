using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// Vehicle controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vehicleService">Vehicle Service</param>
        /// <param name="mapper">Mapper</param>
        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a vehicle
        /// </summary>
        /// <param name="id">Vehicle Id</param>
        /// <returns>Vehicle Dto</returns>
        [HttpGet("{id}")]
        public VehicleDto GetVehicle(int id) => _vehicleService.Get(id);

        /// <summary>
        /// Get all the vehicles
        /// </summary>
        /// <returns>Collection -> Vehicle Dto</returns> 
        [HttpGet]
        public ICollection<VehicleDto> GetAll() => _mapper.Map<ICollection<VehicleDto>>(_vehicleService.GetAll());

        /// <summary>
        /// Insert a vehicle
        /// </summary>
        /// <param name="item">VehicleDto Object</param>
        /// <returns>Vehicle Dto</returns>
        [HttpPost]
        public VehicleDto Insert([FromBody] VehicleDto item) => _vehicleService.Insert(item);

        /// <summary>
        /// Update a vehicle
        /// </summary>
        /// <param name="item">VehicleDto Object</param>
        /// <returns>Vehicle Dto</returns>
        [HttpPut]
        public VehicleDto Update([FromBody] VehicleDto item) => _vehicleService.Update(item);

        /// <summary>
        /// Delete a vehicle
        /// </summary>
        /// <param name="id">Vehicle Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _vehicleService.Delete(id);

    }
}
