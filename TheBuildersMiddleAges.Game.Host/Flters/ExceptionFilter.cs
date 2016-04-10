using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;

namespace TheBuildersMiddleAges.Game.Host.Flters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
        }
    }
}