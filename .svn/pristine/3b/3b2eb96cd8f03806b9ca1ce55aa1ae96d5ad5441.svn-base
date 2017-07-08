using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
namespace IotHubEventProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            string eventProcessorHostName = Guid.NewGuid().ToString();

            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, Helper.IoTtHubD2cEndpoint, EventHubConsumerGroup.DefaultGroupName, Helper.IoTHubConnectionString, Helper.StorageConnectionString, "messages-events");

            Console.WriteLine("Registering EventProcessor...");

            eventProcessorHost.RegisterEventProcessorAsync<StoreEventProcessor>().Wait();

            Console.WriteLine("Receiving ,  Press enter key to stop worker.");
            Console.ReadLine();

            eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
    }
}
