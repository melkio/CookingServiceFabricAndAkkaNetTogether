using Akka.Actor;
using System;

namespace AkkaIntro
{
    public static class ActorsEnvironment
    {
        public static ActorSystem System { get; private set; }
        public static IActorRef Gateway { get; private set; }

        public static void ConfigureAndRun()
        {
            System = ActorSystem.Create("demo");
            Gateway = System.ActorOf<CounterGatewayActor>("counter");
            var ticker = System.ActorOf<TickActor>("ticker");

            System.Scheduler.ScheduleTellRepeatedly(
                initialDelay: TimeSpan.FromSeconds(1),
                interval: TimeSpan.FromMilliseconds(500),
                receiver: ticker,
                message: new Tick(),
                sender: Nobody.Instance);
        }
    }
}
