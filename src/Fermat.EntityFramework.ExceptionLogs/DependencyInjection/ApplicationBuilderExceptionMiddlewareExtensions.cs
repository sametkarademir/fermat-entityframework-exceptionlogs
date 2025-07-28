using Microsoft.AspNetCore.Builder;

namespace Fermat.EntityFramework.ExceptionLogs.DependencyInjection;

public static class ApplicationBuilderExceptionMiddlewareExtensions
{
    public static void FermatExceptionLogMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}