namespace Shared
{
    public class Response
    {
        public string Message { get; set; }

        public bool HasSuccess { get; set; }

        public Exception Exception { get; set; }
    }
}