using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// Delivery controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deliveryService">Delivery Service</param>
        /// <param name="mapper">Mapper</param>
        public DeliveryController(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a delivery
        /// </summary>
        /// <param name="id">Delivery Id</param>
        /// <returns>Delivery Dto</returns>
        [HttpGet("{id}")]
        public DeliveryDto GetDelivery(int id) => _deliveryService.Get(id);

        /// <summary>
        /// Get all the deliverys
        /// </summary>
        /// <returns>Collection -> Delivery Dto</returns> 
        [HttpGet]
        public ICollection<DeliveryDto> GetAll() => _mapper.Map<ICollection<DeliveryDto>>(_deliveryService.GetAll());

        /// <summary>
        /// Insert a delivery
        /// </summary>
        /// <param name="item">DeliveryDto Object</param>
        /// <returns>Delivery Dto</returns>
        [HttpPost]
        public DeliveryDto Insert([FromBody] DeliveryDto item) => _deliveryService.Insert(item);

        /// <summary>
        /// Update a delivery
        /// </summary>
        /// <param name="item">DeliveryDto Object</param>
        /// <returns>Delivery Dto</returns>
        [HttpPut]
        public DeliveryDto Update([FromBody] DeliveryDto item) => _deliveryService.Update(item);

        /// <summary>
        /// Delete a delivery
        /// </summary>
        /// <param name="id">Delivery Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _deliveryService.Delete(id);

    }
}
