namespace Common.Messages
{
    public class Count
    {
        public string CounterId { get; }

        public Count(string counterId)
        {
            CounterId = counterId;
        }
    }
}
