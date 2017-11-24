using Akka.Actor;
using Common.Messages;
using System;

namespace TickerService
{
    public class TickActor : ReceiveActor
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public TickActor()
        {
            Receive<Tick>(message => Handle(message));
        }

        private void Handle(Tick message)
        {
            var counterId = random.Next(1, 5);

            var serviceUri = ServiceProxy.Resolve("fabric:/ServiceFabricAndAkkaNet/CounterService");
            Context
                .ActorSelection($"{serviceUri}/user/counter")
                .Tell(new Count($"{counterId}"));
        }
    }
}
