using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Infrastructure.MvcFilters
{
    public class CarltonStandardResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objResult)
            {
                objResult.Value = new ApiResult(context.HttpContext.Response.StatusCode, "", objResult.Value);
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
           
        }
    }
}
