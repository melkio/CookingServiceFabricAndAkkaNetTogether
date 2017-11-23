using System;
using Akka.Actor;

namespace AkkaIntro
{
    public class CounterActor : ReceiveActor
    {
        private const int MIN = -5;
        private const int MAX = 5;

        private int value;

        public CounterActor() => Become(Up);

        private void Up()
        {
            Receive<Count>(message =>
            {
                value++;
                if (value >= MAX)
                    Become(Down);

                Console.WriteLine($"Current value: {value}");
            });
        }

        private void Down()
        {
            Receive<Count>(message =>
            {
                value--;
                if (value <= MIN)
                    Become(Up);

                Console.WriteLine($"Current value: {value}");
            });
        }
    }
}
