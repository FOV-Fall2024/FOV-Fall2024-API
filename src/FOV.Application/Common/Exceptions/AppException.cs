using System.Globalization;

namespace FOV.Application.Common.Exceptions;
public class AppException : Exception
{
    public List<string> Errors { get; }

    public AppException() : base()
    {
        Errors = new List<string>();
    }

    public AppException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }

    public AppException(List<string> errors) : base("One or more errors occurred.")
    {
        Errors = errors ?? new List<string>();
    }

    public AppException(string message, List<string> errors) : base(message)
    {
        Errors = errors ?? new List<string>();
    }

    public AppException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = new List<string> { message };
    }

    public AppException(string message, List<string> errors, Exception innerException) : base(message, innerException)
    {
        Errors = errors ?? [];
    }
}
