using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace MessageProcessRedis
{
    class Program
    {
        private const string SingleRChannel = "signalRChannel";
        static void Main(string[] args)
        {
            IDatabase redisCache = Helper.RedisConnection.GetDatabase();
            ISubscriber redisSub = Helper.RedisConnection.GetSubscriber();

            //SubscriptionClient subscriptionClient = Helper.subscriptionClient;

            //OnMessageOptions options = new OnMessageOptions();
            //options.AutoComplete = true;
            //options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            var connectionString = "Endpoint=sb://hhnext.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=E3oBKoqAB/7f6uUNuBQz5+NFQt+vKa4LsibADQMy5go=";
            var topicName = "hhnext-topic";
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, "hhnext-subscribe-redis");
            //subscriptionClient.OnMessage(message =>
            //{
            //    Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
            //    Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
            //});

            subscriptionClient.OnMessage((message) =>
            {
                message.Complete();
                try
                {

                    //Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
                    Console.WriteLine(String.Format("Message id: {0}", message.MessageId));

                    var bodyAsString = message.GetBody<string>();
                    //var bodyStream = message.GetBody<Stream>();
                    //bodyStream.Position = 0;
                    //var bodyAsString = new StreamReader(bodyStream, Encoding.ASCII).ReadToEnd();
                    Console.WriteLine(String.Format("Message body: {0}", bodyAsString));
                  
                    JObject bodyAsJson = JObject.Parse(bodyAsString);

                    //Console.WriteLine("MessageId: {0} ", message.MessageId);
                    //Console.WriteLine("message: {0} ", bodyAsString);

                    //string projectName = (string)bodyAsJson["ProjectName"];
                    string deviceId = (string)bodyAsJson["deviceId"];
                    string timestamp = (string)bodyAsJson["timestamp"];
                    JObject data = (JObject)bodyAsJson["data"];

                    List<HashEntry> hesDevice = new List<HashEntry>();
                    List<HashEntry> hesProject = new List<HashEntry>();

                    string deviceIndex, deviceValue;
                    JObject pubDataJson = new JObject();
                    foreach (JProperty property in data.Properties())
                    {
                        deviceValue = property.Value.ToString();
                        hesDevice.Add(new HashEntry(property.Name, deviceValue));

                        deviceIndex = redisCache.HashGet("device:" + deviceId + ":Id", property.Name);
                        hesProject.Add(new HashEntry(deviceIndex, deviceValue));

                        pubDataJson[deviceIndex] = deviceValue;

                    }

                    redisCache.HashSet("device:" + deviceId + ":values", hesDevice.ToArray());
                    string projectId = redisCache.StringGet("device:" + deviceId + ":project");
                    redisCache.HashSet("project:" + projectId + ":values", hesProject.ToArray());

                    //dynamic newData = new JObject();
                    //newData.DeviceId = deviceId;
                    //newData.Data = data;

                    //Console.WriteLine("signal message : {0} ", newData.ToString());


                    string pubDataStr = JsonConvert.SerializeObject(pubDataJson);
                    Console.WriteLine("signal message : {0} ,{1},{2}", pubDataStr, timestamp, DateTime.Now.ToShortTimeString());

                    redisSub.Publish(SingleRChannel, pubDataStr);

                    //message.Complete();

                }
                catch (Exception e)
                {
                    message.Abandon();
                }

            });

            Console.WriteLine("Redis Receiving interactive messages from SB queue...");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

    }
}
