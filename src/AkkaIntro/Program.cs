using Akka.Actor;
using System;

namespace AkkaIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("demo");
            var actor = system.ActorOf<CounterActor>("counter");

            actor.Tell(new Count("42"));

            Console.ReadLine();
        }
    }
}
