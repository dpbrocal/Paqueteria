using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// Carrier controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carrierService">Carrier Service</param>
        /// <param name="mapper">Mapper</param>
        public CarrierController(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a carrier
        /// </summary>
        /// <param name="id">Carrier Id</param>
        /// <returns>Carrier Dto</returns>
        [HttpGet("{id}")]
        public CarrierDto GetCarrier(int id) => _carrierService.Get(id);

        /// <summary>
        /// Get all the carriers
        /// </summary>
        /// <returns>Collection -> Carrier Dto</returns> 
        [HttpGet]
        public ICollection<CarrierDto> GetAll() => _mapper.Map< ICollection < CarrierDto >>(_carrierService.GetAll());


        /// <summary>
        /// Update a carrier
        /// </summary>
        /// <param name="item">CarrierDto Object</param>
        /// <returns>Carrier Dto</returns>
        [HttpPut]
        public CarrierRegisterDto Update([FromBody] CarrierRegisterDto item)
        {
            item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
            return _carrierService.Update(item);
        }

        /// <summary>
        /// Delete a carrier
        /// </summary>
        /// <param name="id">Carrier Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _carrierService.Delete(id);

    }
}
