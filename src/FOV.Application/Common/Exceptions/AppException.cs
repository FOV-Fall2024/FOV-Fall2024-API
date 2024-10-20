﻿using System.Globalization;
using OpenTelemetry.Trace;

namespace FOV.Application.Common.Exceptions;
public class AppException : Exception
{
    public List<string> Errors { get; }
    public List<FieldError> FieldErrors { get; }
    public int StatusCode { get; } = 400;

    public AppException() : base()
    {
        Errors = new List<string>();
        FieldErrors = new List<FieldError>();
    }

    public AppException(string message) : base(message)
    {
        Errors = new List<string> { message };
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppException(List<string> errors) : base("One or more errors occurred.")
    {
        Errors = errors ?? new List<string>();
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppException(string message, List<string> errors) : base(message)
    {
        Errors = errors ?? new List<string>();
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = new List<string> { message };
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppException(string message, List<string> errors, Exception innerException) : base(message, innerException)
    {
        Errors = errors ?? new List<string>();
        FieldErrors = new List<FieldError>();
        StatusCode = 400;

    }

    public AppException(string message, List<FieldError> fieldErrors,int statusCode) : base(message)
    {
        Errors = new List<string>();
        FieldErrors = fieldErrors ?? new List<FieldError>();
        StatusCode = statusCode;
    }

    public AppException(string message, List<FieldError> fieldErrors) : base(message)
    {
        Errors = new List<string>();
        FieldErrors = fieldErrors ?? new List<FieldError>();
    }

    public AppException(string message, List<FieldError> fieldErrors, Exception innerException) : base(message, innerException)
    {
        Errors = new List<string>();
        FieldErrors = fieldErrors ?? new List<FieldError>();
        StatusCode = 400;
    }

}
