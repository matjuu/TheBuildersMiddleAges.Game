using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace TheBuildersMiddleAges.Game.Host.Flters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            IList<MediaTypeHeaderValue> value = new[] {new MediaTypeHeaderValue("application/x-www-form-urlencoded")};
            value[0].Parameters.Add(new NameValueHeaderValue("Access-Control-Allow-Origin", "*"));

            context.Result = new BadRequestObjectResult("")
            {
                ContentTypes = value,
                StatusCode = 400,
                Value = context.Exception.Message,
                Formatters = new List<IOutputFormatter>()
            };
        }
    }
}