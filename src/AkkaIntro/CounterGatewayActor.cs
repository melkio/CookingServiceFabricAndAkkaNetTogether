using Akka.Actor;

namespace AkkaIntro
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
                actor = Context.ActorOf<FailCounterActor>(message.CounterId);

            actor.Forward(message);
        }
    }
}
