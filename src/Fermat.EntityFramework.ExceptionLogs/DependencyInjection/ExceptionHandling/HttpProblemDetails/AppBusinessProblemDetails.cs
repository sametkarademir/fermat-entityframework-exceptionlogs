using Fermat.EntityFramework.ExceptionLogs.DependencyInjection.ExceptionHandling.Abstracts;
using Fermat.Domain.Exceptions.Models;

namespace Fermat.EntityFramework.ExceptionLogs.DependencyInjection.ExceptionHandling.HttpProblemDetails;

public class AppBusinessProblemDetails : AppProblemDetails
{
    public AppBusinessProblemDetails(
        string? code,
        string? message,
        string? details,
        int? statusCode,
        string? correlationId,
        List<ValidationExceptionModel>? validationErrors)
        : base(code, message, details, statusCode, correlationId, validationErrors)
    {
    }
}