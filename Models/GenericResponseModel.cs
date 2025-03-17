namespace YaradiciEduAz.Models
{
    public class GenericResponseModel<T>
    {
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public string[]? Meta { get; set; }
        public string[]? Links { get; set; }
        public GenericResponseModel()
        {
            StatusCode = 404;
            Message = "Not Found";
        }
    }
}
