namespace LMS.BlazorUI.Data.Models
{
    public class ServiceResponse<T>
    {
        public T ResponseData { get; set; }
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
