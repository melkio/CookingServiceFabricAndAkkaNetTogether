using Akka.Actor;
using Akka.Configuration;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace CounterService
{
    public class RemoteCommunicationListener : ICommunicationListener
    {
        private static readonly string HoconConfiguration = @"
akka {
    actor {
        provider = remote
    }
    remote {
        dot-netty.tcp {
            port = 9002 
            hostname = localhost
        }
    }
}";

        private readonly StatelessServiceContext context;
        private ActorSystem system;

        public RemoteCommunicationListener(StatelessServiceContext context)
        {
            this.context = context;
        }

        public void Abort()
        {
            system?.Dispose();
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            system?.Terminate().Wait(cancellationToken);
            system?.Dispose();

            return Task.CompletedTask;
        }

        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            var endpoint = context.CodePackageActivationContext.GetEndpoint("AkkaEndpoint");

            var config = ConfigurationFactory
                .ParseString($"akka.remote.dot-netty.tcp.hostname = {context.NodeContext.IPAddressOrFQDN}")
                .WithFallback($"akka.remote.dot-netty.tcp.port = {endpoint.Port}")
                .WithFallback(HoconConfiguration);
            system = ActorSystem.Create("Counter", config);

            system.ActorOf<CounterGatewayActor>("counter");

            return Task.FromResult($"akka.tcp://{system.Name}@{context.NodeContext.IPAddressOrFQDN}:{endpoint.Port}");
        }
    }
}
