using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net;

namespace Carlton.Infrastructure.ApiResponse
{
    public class CarltonApiResponse
    {
        public static CarltonApiResponse CreateSuccessResponse(int code, string message, object result)
        {
            return new CarltonApiResponse(code, message, result);
        }

        public static CarltonApiResponse CreateForbiddenResponse(IEnumerable<ValidationFailure> errors)
        {
            return new CarltonApiResponse((int) HttpStatusCode.BadRequest, "The server was unable to process the request due to validation errors.", errors);
        }

        public static CarltonApiResponse CreateConflictResponse()
        {
            return new CarltonApiResponse((int)HttpStatusCode.Conflict, "The server was unable to process the request due to a conflict with the current state of the target resource.");
        }

        public static CarltonApiResponse CreateNotFoundResponse()
        {
            return new CarltonApiResponse((int)HttpStatusCode.NotFound, "The server was unable to locate the requested resource."); 
        }

        public static CarltonApiResponse CreateUnauthorizedResponse()
        {
            return new CarltonApiResponse((int)HttpStatusCode.Forbidden, "You are not permitted to access this resource.");
        }

        public static CarltonApiResponse CreateServiceUnavailableResponse()
        {
            return new CarltonApiResponse((int)HttpStatusCode.BadGateway, "Unable to reach remote service.");
        }

        public static CarltonApiResponse CreateInternalServerErrorResponse()
        {
            return new CarltonApiResponse((int)HttpStatusCode.InternalServerError, "Server experienced and internal error.");
        }

        private CarltonApiResponse(int code, string message, object result)
        {
            Code = code;
            Message = message;
            Result = result;
        }

        private CarltonApiResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        private CarltonApiResponse(int code, string message, string[] validationErrors)
        {
            Code = code;
            Message = message;
            ValidationErrors = validationErrors;
        }

        public string Version { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiResponseStatus Status
        {
            get
            {
                return ((int)Code >= 200) && ((int)Code <= 299)
                    ? ApiResponseStatus.OK : ApiResponseStatus.ERROR;
            }
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] ValidationErrors {get;set;}

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}

