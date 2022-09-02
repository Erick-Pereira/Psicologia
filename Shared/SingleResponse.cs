namespace Shared
{
    public class SingleResponse<T> : Response
    {
        public T Item { get; set; }
    }
}