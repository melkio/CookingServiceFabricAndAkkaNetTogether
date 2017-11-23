using Akka.Actor;
using System;

namespace AkkaIntro
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

            Context.ActorSelection("/user/counter")
                .Tell(new Count($"{counterId}"));
        }
    }
}
