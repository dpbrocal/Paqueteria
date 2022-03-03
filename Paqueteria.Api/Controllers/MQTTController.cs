
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paqueteria.Models.Dtos;
using Paqueteria.Publisher;
using Paqueteria.Services.Interfaces;
using Paqueteria.Subscriber;
using System;
using System.Threading.Tasks;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// MQTT controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MQTTController : ControllerBase
    {
        private PublisherMqtt _publisher;
        private SubscriberMqtt _subscriber;
        private readonly ILocationHistoryService _locationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="locationService">LocationHistory Service</param>
        public MQTTController(ILocationHistoryService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Request with MQTT
        /// </summary>
        /// <remarks>Launches the subscriber to listen</remarks>
        [HttpPost]
        public async Task ConnectMQTT()
        {
            //Conectamos
            this._subscriber = new SubscriberMqtt(_locationService);
            try
            {
                await this._subscriber.Connect();

            }
            catch (Exception e)
            {
                Console.WriteLine("SUBSCRIBER ERROR");
            }

        }

        /// <summary>
        /// Location change
        /// </summary>
        /// <remarks>Launches the publisher to listen and sends a message</remarks>
        /// <param name="item">LocationHistoryDto Object</param>
        [HttpPost("location")]
        public async Task LocationChange([FromBody] LocationHistoryDto item)
        {
            this._publisher = new PublisherMqtt();
            try
            {
                await this._publisher.Connect();
                await this._publisher.Publish(item);

                //Save DB
                await _locationService.InsertASync(item);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR >>>>> RESEND REQUEST");
            }
            
            
        }
    }
}
