namespace FOV.Presentation.Infrastructure.Core;

public static class ErrorStatusCodeConfig
{
    public const int BAD_REQUEST = 404;
    public const int CONFLICT = 403;
}

public static class ErrorReasonStatusCodeConfig
{
    public const string BAD_REQUEST = "Bad Request Error!";
    public const string CONFLICT = "Conflict Error";

}

public class Error<T>
{
    public string Message { get; set; }

    public int StatusCode { get; set; }
    public List<T> Errors { get; set; }

    public Error()
    {

    }

    public Error(string message = ErrorReasonStatusCodeConfig.BAD_REQUEST, int statusCode = ErrorStatusCodeConfig.BAD_REQUEST, List<T> errors = null)
    {
        Message = message;
        StatusCode = statusCode;
        Errors = errors;
    }
}


