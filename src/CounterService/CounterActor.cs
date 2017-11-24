using Akka.Actor;
using Common.Messages;

namespace CounterService
{
    public class CounterActor : ReceiveActor
    {
        private const int MIN = -5;
        private const int MAX = 5;

        private int value;

        public CounterActor() => Become(Up);

        private void Up()
        {
            Receive<Count>(message =>
            {
                value++;
                if (value >= MAX)
                    Become(Down);
            });
        }

        private void Down()
        {
            Receive<Count>(message =>
            {
                value--;
                if (value <= MIN)
                    Become(Up);
            });
        }
    }
}
