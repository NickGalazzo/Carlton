using Carlton.Infrastructure.ApiResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carlton.Infrastructure.MvcFilters
{
    public class CarltonStandardResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {

            switch (context.Result)
            {
                case ObjectResult objResult:
                    objResult.Value = new ApiResult(context.HttpContext.Response.StatusCode, "", objResult.Value);
                    break;
                case StatusCodeResult statusCodeResult:
                    context.Result = new ObjectResult(
                        new ApiResult(context.HttpContext.Response.StatusCode, "", null));
                    break;
                case ContentResult contentResult:
                    context.Result = new ObjectResult(
                        new ApiResult(context.HttpContext.Response.StatusCode, "", contentResult.Content));
                    break;
                default:
                    break;
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}
