

namespace SharedProject.Middlewars;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception  
        _logger.LogError(exception, exception.Message);

        //ToDo Create a standardized error response  
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected  
        var result = JsonSerializer.Serialize(new
        {
            error = "An unexpected error occurred.",
            details = exception.Message 
            // ToDo control this for security reasons  
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
