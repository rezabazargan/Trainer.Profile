using Microsoft.AspNetCore.Diagnostics;
using Trainer.Profile.Application.Contracts.Exceptions;

namespace Trainer.Profile.Api.ExceptionHandler;

public class GeneralExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case ValidationException validationException:
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response
                    .WriteAsJsonAsync(new { validationException.Errors }, cancellationToken);
                return true;
            default:
                return false;
        }
    }
}