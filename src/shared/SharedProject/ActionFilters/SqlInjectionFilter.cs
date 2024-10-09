
namespace SharedProject.ActionFilters;

public class SqlInjectionFilter : ActionFilterAttribute
{
    private static readonly Regex sqlInjectionPattern = new Regex(
        @"(exec|execute|count|drop|select|insert|update|delete|union|;|--|'|""|\bOR\b|\bAND\b|\bWHERE\b|#)",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var ActionArgument in context.ActionArguments)
        {
            if (ActionArgument.Value is string value && IsPotentialSqlInjection(value))
            {
                context.Result = new BadRequestObjectResult("Potential SQL Injection attempt detected.");
                return;
            }
        }

        base.OnActionExecuting(context);
    }

    private bool IsPotentialSqlInjection(string value)
    {
        return sqlInjectionPattern.IsMatch(value);
    }
}
