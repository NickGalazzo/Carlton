using Carlton.Infrastructure.ApiResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carlton.Infrastructure.MvcFilters
{
    public class CarltonStandardResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var statusCode = context.HttpContext.Response.StatusCode;

            switch (context.Result)
            {
                case ObjectResult objResult:
                    objResult.Value = new JsonResult(
                        new ApiResult(statusCode, "", objResult.Value));
                    break;
                case StatusCodeResult statusCodeResult:
                    context.Result = new JsonResult(
                        new ApiResult(statusCode, "", null));
                    break;
                case ContentResult contentResult:
                    context.Result = new JsonResult(
                        new ApiResult(statusCode, "", contentResult.Content));
                    break;
                case JsonResult jsonResult:
                    context.Result = new JsonResult(
                        new ApiResult(statusCode, "", jsonResult.Value));
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
