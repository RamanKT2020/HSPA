using System.Text.Json;

namespace WebAPI.Errors
{
    public class ApiError
    {
        public ApiError(int errorCode, string errorMessage, string errorDetails = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }

        //Serialize the object to pass from one domain to the other, transmit to a database, or to a file
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        
    }
}