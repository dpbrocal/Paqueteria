using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Packets;
using Paqueteria.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paqueteria.Publisher
{
    public class PublisherMqtt
    {
        private IMqttClient client;

        public PublisherMqtt()
        {

        } 

        public async Task Connect()
        {
            var mqttFactory = new MqttFactory();
            client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                                .WithClientId(Guid.NewGuid().ToString())
                                .WithTcpServer("test.mosquitto.org", 1883)
                                .WithCleanSession()
                                .WithKeepAlivePeriod(TimeSpan.FromSeconds(120))
                                .Build();

            client.UseConnectedHandler(e =>
            {
                Console.WriteLine("BROKER CONNECTED");

            });

            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("BROKER DISCONNECTED");
            });

            await client.ConnectAsync(options);
        }

        public async Task Publish(LocationHistoryDto locationHistoryDto)
        {
            //Send event
            var data = locationHistoryDto.VehicleId + "," + locationHistoryDto.XCoord + "," + locationHistoryDto.YCoord;
            var message = new MqttApplicationMessageBuilder()
                                .WithTopic("location")
                                .WithPayload(data)
                                .WithAtLeastOnceQoS()
                                .Build();
            if (client.IsConnected)
            {
                
                await client.PublishAsync(message);
                await client.DisconnectAsync();
            }
        }

    }
}
