using Akka.Actor;
using Common.Messages;

namespace CounterService
{
    public class CounterGatewayActor : ReceiveActor
    {
        public CounterGatewayActor()
        {
            Receive<Count>(message => Handle(message));
        }

        private void Handle(Count message)
        {
            var actor = Context.Child(message.CounterId);
            if (actor.IsNobody())
                actor = Context.ActorOf<CounterActor>(message.CounterId);

            actor.Forward(message);
        }
    }
}
