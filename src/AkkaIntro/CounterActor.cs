using System;
using Akka.Actor;

namespace AkkaIntro
{
    public class CounterActor : ReceiveActor
    {
        private int value;

        public CounterActor()
        {
            Receive<Count>(message => Handle(message));
        }

        private void Handle(Count message)
        {
            value++;
            Console.WriteLine($"Current value: {value}");
        }
    }
}
