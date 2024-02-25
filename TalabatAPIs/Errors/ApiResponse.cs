namespace TalabatAPIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode , string? message=null)
        {
            StatusCode = statusCode ;
            Message = message ?? GetDegaultMessageFromStatusCode(statusCode);
        }

        private string? GetDegaultMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request you have made",
                401 => "Auothrized, you have not",
                404 => "Resource NOT Found",
                500 => "Errors are the path to the dark side,Erros lead to anger,anger lead to hate , hate lead to shift career",
                _ => null
            };
        }
    }
}
