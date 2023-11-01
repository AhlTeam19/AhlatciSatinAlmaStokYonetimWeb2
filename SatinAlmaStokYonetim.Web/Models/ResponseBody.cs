namespace SatinAlmaStokYonetim.Models
{
    public class ResponseBody<T>
    {
        public int StatusCode { get; set; }
        public T data { get; set; }
        public List<string> errorMessages { get; set; }
    }
}
