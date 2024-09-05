namespace FOV.Presentation.Infrastructure.Core;



public static class StatusCodeConfig
{
    public const int OK = 200;
    public const int CREATED = 201;
    public const int NO_CONTENT = 204;
}

public static class ReasonStatusCodeConfig
{
    public const string CREATED = "Created!";
    public const string OK = "Success";
    public const string UPDATED = "Updated!";
    public const string DELETED = "Deleted!";

}

public class SuccessResponse<T>
{
    public string Message { get; set; } = string.Empty;

    public int StatusCode { get; set; }

    public string ReasonStatusCode { get; set; }
    public T Metadata { get; set; } = default(T);

    public SuccessResponse()
    {

    }

    public SuccessResponse(string message, int statusCode = StatusCodeConfig.OK, string reasonStatus = ReasonStatusCodeConfig.OK, T metadata = default(T))
    {
        Message = message;
        StatusCode = statusCode;
        ReasonStatusCode = reasonStatus;
        Metadata = metadata;
    }
}

// Using object for metadata here, which could be null by default
public class OK_Result<T>(string message = "Fetch Successfully", T metadata = default(T)) : SuccessResponse<T>(message, StatusCodeConfig.OK, ReasonStatusCodeConfig.OK, metadata)
{
}

public class CREATED_Result(string message = "Create Successfully", object metadata = null) : SuccessResponse<object>(message, StatusCodeConfig.CREATED, ReasonStatusCodeConfig.CREATED, metadata)
{
}

public class UPDATED_Result(string message, object metadata = null) : SuccessResponse<object>(message, StatusCodeConfig.NO_CONTENT, ReasonStatusCodeConfig.UPDATED, metadata)
{
}

public class DELETED_Result(string message, object metadata = null) : SuccessResponse<object>(message, StatusCodeConfig.NO_CONTENT, ReasonStatusCodeConfig.DELETED, metadata)
{
}
