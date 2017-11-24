using Microsoft.ServiceFabric.Services.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading;

namespace TickerService
{
    public class ServiceProxy
    {
        public static string Resolve(string serviceName)
        {
            var resolver = ServicePartitionResolver.GetDefault();

            var partition = resolver
                .ResolveAsync(new Uri(serviceName), new ServicePartitionKey(), CancellationToken.None)
                .GetAwaiter()
                .GetResult();
            var endpoint = partition.GetEndpoint();
            var addresses = JObject.Parse(endpoint.Address);

            return (string)addresses["Endpoints"].First();
        }
    }
}
