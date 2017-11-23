namespace AkkaIntro
{
    public class GetValue
    {
        public class Request
        {
            public string CounterId { get; }

            public Request(string counterId)
            {
                CounterId = counterId;
            }
        }

        public class Response
        {
            public int Value { get; }

            public Response(int value)
            {
                Value = value;
            }
        }
    }
}
