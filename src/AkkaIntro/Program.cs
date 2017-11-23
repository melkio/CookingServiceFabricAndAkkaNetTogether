using Akka.Actor;
using System;

namespace AkkaIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("demo");
            var actor = system.ActorOf<CounterGatewayActor>("counter");

            system.Scheduler.ScheduleTellRepeatedly(
                initialDelay: TimeSpan.FromSeconds(1),
                interval: TimeSpan.FromMilliseconds(500),
                receiver: actor,
                message: new Count("42"),
                sender: Nobody.Instance);

            Console.ReadLine();
        }
    }
}
