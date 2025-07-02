namespace CarDealerAPI.Utils
{
    public class HttpMessage
    {
        public string Message { get; set; } = null!;

        public HttpMessage(string message)
        {
            Message = message;
        }
    }
}
