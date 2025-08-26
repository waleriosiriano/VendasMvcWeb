namespace VendasMvcWeb.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
