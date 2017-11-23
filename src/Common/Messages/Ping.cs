namespace Common.Messages
{
    public class Ping
    {
        public int Value { get; }

        public Ping(int value)
        {
            Value = value;
        }
    }
}
