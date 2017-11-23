using Akka.Actor;

namespace AkkaIntro
{
    public class CounterActor : ReceiveActor
    {
        private int value;

        public CounterActor()
        {
            Receive<Count>(message => value++);
        }
    }
}
