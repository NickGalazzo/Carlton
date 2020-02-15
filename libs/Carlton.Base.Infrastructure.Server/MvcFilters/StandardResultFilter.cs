﻿using Carlton.Base.Infrastructure.Server.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carlton.Base.Infrastructure.Server.MvcFilters
{
    public class StandardResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var statusCode = context.HttpContext.Response.StatusCode;

            switch(context.Result)
            {
                case ObjectResult objResult:
                    objResult.Value = new ObjectResult(
                        StandardApiResponse.CreateSuccessResponse(statusCode, "", objResult.Value));
                    break;
                case StatusCodeResult statusCodeResult:
                    context.Result = new ObjectResult(
                       StandardApiResponse.CreateSuccessResponse(statusCode, "", null));
                    break;
                case ContentResult contentResult:
                    context.Result = new ObjectResult(
                        StandardApiResponse.CreateSuccessResponse(statusCode, "", contentResult.Content));
                    break;
                default:
                    break;
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //Method intentionally left empty
        }
    }
}