using System;
using Akka.Actor;
using Common.Messages;

namespace PongHost
{
    public class PongActor : ReceiveActor
    {
        public PongActor()
        {
            Receive<Ping>(message => Handle(message));
        }

        private void Handle(Ping message)
        {
            Console.WriteLine($"Ping received with value {message.Value}");
            Sender.Tell(new Pong(message.Value + 1));
        }
    }
}
