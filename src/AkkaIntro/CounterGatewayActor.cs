using Akka.Actor;

namespace AkkaIntro
{
    public class CounterGatewayActor : ReceiveActor
    {
        public CounterGatewayActor()
        {
            Receive<Count>(message => Handle(message));
            Receive<GetValue.Request>(message => Handle(message));
        }

        private void Handle(Count message)
        {
            var actor = Context.Child(message.CounterId);
            if (actor.IsNobody())
                actor = Context.ActorOf<FailCounterActor>(message.CounterId);

            actor.Forward(message);
        }

        private void Handle(GetValue.Request message)
        {
            var actor = Context.Child(message.CounterId);
            actor.Forward(message);
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new AllForOneStrategy(Decider.From(x => Directive.Restart));
        }
    }
}
