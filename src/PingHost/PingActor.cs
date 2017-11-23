using System;
using Akka.Actor;
using Common.Messages;

namespace PingHost
{
    public class PingActor : ReceiveActor
    {
        public PingActor()
        {
            Receive<Pong>(message => Handle(message));
        }

        private void Handle(Pong message)
        {
            Console.WriteLine($"Pong received with value {message.Value}");
            Sender.Tell(new Ping(message.Value + 1));
        }
    }
}
