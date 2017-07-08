using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.ServiceBus.Messaging;

namespace MessageProcessRedis
{
    class Helper
    {

        private static Lazy<ConnectionMultiplexer> lazyRedisConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisCacheConnection"].ToString());
            //return ConnectionMultiplexer.Connect("hhnext.redis.cache.windows.net" + ",abortConnect=false,ssl=true,password=" + "2a8N8qu0H86t4UmXhWTwCjdmGq0EUZHYBqsCgB23j5Q=");

        });
        public static ConnectionMultiplexer RedisConnection
        {
            get
            {
                return lazyRedisConnection.Value;
            }
        }

         public static SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(ConfigurationManager.AppSettings["ServiceBusconnectionString"], "hhnext-topic", "hhnext-subscribe-redis");

    }
}
