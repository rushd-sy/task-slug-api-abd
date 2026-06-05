using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace SlugGenerator.Api.Infrastructure;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {

        _logger.LogError(exception, "An exception occurred: {Message}", exception.Message);

        var statusCode = StatusCodes.Status500InternalServerError;
        var title = "Server Error";
        var detail = "An unexpected error occurred while processing your request. Please try again later.";

        if (exception is ArgumentException argumentException)
        {
            statusCode = StatusCodes.Status400BadRequest;
            title = "Validation Error";
            detail = argumentException.Message; 
        }

        var problemDetails = new ProblemDetails
        {
            Status = statusCode, 
            Title = title, 

            Detail = detail
        };


        httpContext.Response.StatusCode = problemDetails.Status.Value;
        httpContext.Response.ContentType = "application/problem+json";

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}