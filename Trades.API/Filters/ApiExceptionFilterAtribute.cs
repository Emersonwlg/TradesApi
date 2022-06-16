using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Trades.API.Filters
{
    public class ApiExceptionFilterAtribute: ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApiExceptionFilterAtribute(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(context.Exception.Message);
            _logger.Error($"{context.Result}");
            base.OnException(context);
        }
    }
}
