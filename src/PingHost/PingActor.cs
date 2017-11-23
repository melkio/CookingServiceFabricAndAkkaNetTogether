using System;
using Akka.Actor;
using Common.Messages;

namespace PingHost
{
    public class PingActor : ReceiveActor
    {
        public PingActor()
        {
            Receive<Start>(message => Handle(message));
            Receive<Pong>(message => Handle(message));
        }

        private void Handle(Start message)
        {
            Context
                .ActorSelection("akka.tcp://Pong@localhost:9002/user/pong")
                .Tell(new Ping(1));
        }

        private void Handle(Pong message)
        {
            Console.WriteLine($"Pong received with value {message.Value}");
            Sender.Tell(new Ping(message.Value + 1));
        }
    }
}
