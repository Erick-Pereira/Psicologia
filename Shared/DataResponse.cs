namespace Shared
{
    public class DataResponse<T> : Response
    {
        public List<T> Data { get; set; }
    }
}