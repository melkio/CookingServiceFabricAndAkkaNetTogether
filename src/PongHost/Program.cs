using Akka.Actor;
using Akka.Configuration;
using System;

namespace PongHost
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
            port = 9002 
            hostname = localhost
        }
    }
}";
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(Hocon);
            var system = ActorSystem.Create("Pong", config);

            var actor = system.ActorOf<PongActor>("pong");

            Console.ReadLine();
        }
    }
}
