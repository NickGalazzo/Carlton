using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net;

namespace Carlton.Base.Infrastructure.Server.ApiResponse
{
    public class StandardApiResponse
    {
        public static StandardApiResponse CreateSuccessResponse(int code, string message, object result)
        {
            return new StandardApiResponse(code, message, result);
        }

        public static StandardApiResponse CreateForbiddenResponse(IEnumerable<ValidationFailure> errors)
        {
            return new StandardApiResponse((int) HttpStatusCode.BadRequest, "The server was unable to process the request due to validation errors.", errors);
        }

        public static StandardApiResponse CreateConflictResponse()
        {
            return new StandardApiResponse((int)HttpStatusCode.Conflict, "The server was unable to process the request due to a conflict with the current state of the target resource.");
        }

        public static StandardApiResponse CreateNotFoundResponse()
        {
            return new StandardApiResponse((int)HttpStatusCode.NotFound, "The server was unable to locate the requested resource."); 
        }

        public static StandardApiResponse CreateUnauthorizedResponse()
        {
            return new StandardApiResponse((int)HttpStatusCode.Forbidden, "You are not permitted to access this resource.");
        }

        public static StandardApiResponse CreateServiceUnavailableResponse()
        {
            return new StandardApiResponse((int)HttpStatusCode.BadGateway, "Unable to reach remote service.");
        }

        public static StandardApiResponse CreateInternalServerErrorResponse()
        {
            return new StandardApiResponse((int)HttpStatusCode.InternalServerError, "Server experienced and internal error.");
        }

        private StandardApiResponse(int code, string message, object result)
        {
            Code = code;
            Message = message;
            Result = result;
        }

        private StandardApiResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        private StandardApiResponse(int code, string message, string[] validationErrors)
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
                return (Code >= 200) && (Code <= 299)
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

