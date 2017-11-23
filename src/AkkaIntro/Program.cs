using Akka.Actor;
using System;

namespace AkkaIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("demo");
            var counter = system.ActorOf<CounterGatewayActor>("counter");
            var ticker = system.ActorOf<TickActor>("ticker");

            system.Scheduler.ScheduleTellRepeatedly(
                initialDelay: TimeSpan.FromSeconds(1),
                interval: TimeSpan.FromMilliseconds(500),
                receiver: ticker,
                message: new Tick(),
                sender: Nobody.Instance);

            Console.ReadLine();
        }
    }
}
