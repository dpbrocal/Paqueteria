
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Paqueteria.Subscriber
{
    public class SubscriberMqtt
    {

        private readonly ILocationHistoryService _locationService;

        public SubscriberMqtt(ILocationHistoryService locationService)
        {
            _locationService = locationService;
        }

        public async Task Connect()
        {
            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                                .WithClientId(Guid.NewGuid().ToString())
                                .WithTcpServer("test.mosquitto.org", 1883)
                                .WithCleanSession()
                                .WithKeepAlivePeriod(TimeSpan.FromSeconds(120))
                                .Build();

            client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("SUBSCRIBER CONNECTED");
                //Subscriber connected
                var topicFilter = new MqttTopicFilterBuilder()
                                        .WithTopic("location")
                                        .Build();

                await client.SubscribeAsync(topicFilter);
            });

            client.UseDisconnectedHandler(e =>
            {
                //Cliente desconetado del broker
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                //Message received

                
                var msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string[] vars = msg.Split(',');

                LocationHistoryDto item = new LocationHistoryDto
                {
                    VehicleId = Convert.ToInt64(vars[0]),
                    XCoord = Convert.ToInt32(vars[1]),
                    YCoord = Convert.ToInt32(vars[2]),
                    Date = DateTime.Now
                };

                if (e.ApplicationMessage.Topic == "location")
                {
                    Console.WriteLine("Vehiculo: " + item.VehicleId + "\n" +
                                      "Coordenada X: " + item.XCoord + "\n" +
                                      "Coordenada Y: " + item.YCoord + "\n" + 
                                      "Fecha: " + item.Date);
                }
            });

            await client.ConnectAsync(options);
        }

        public async Task Disconnect(IMqttClient client)
        {
            await client.DisconnectAsync();
        }
    }
}
