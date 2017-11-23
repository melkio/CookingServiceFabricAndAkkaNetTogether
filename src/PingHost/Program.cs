using Akka.Actor;
using Akka.Configuration;
using System;

namespace PingHost
{
    class Program
    {
        private static readonly string Hocon = @"
akka {
    actor {
        provider = remote
    }
    remote {
        dot-netty.tcp {
            port = 9001 
            hostname = localhost
        }
    }
}";
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(Hocon);
            var system = ActorSystem.Create("Ping", config);

            var actor = system.ActorOf<PingActor>("ping");
            actor.Tell(new Start());

            Console.ReadLine();
        }
    }
}
