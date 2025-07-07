namespace CarDealerAPI.Utils
{
    public class ValidationErrorResponse
    {
        public Dictionary<string, string[]> Errors { get; set; }

        public ValidationErrorResponse(Dictionary<string, string[]> errors)
        {
            Errors = errors;
        }
    }
}
