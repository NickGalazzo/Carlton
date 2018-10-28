using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Carlton.Infrastructure.ApiResults
{
    public class ApiResult
    {
        public ApiResult(int code, string message, object result)
        {
            Code = code;
            Message = message;
            Result = result;
        }

        public string Version { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiResultStatus Status
        {
            get
            {
                return ((int)Code >= 200) && ((int)Code <= 299)
                    ? ApiResultStatus.OK : ApiResultStatus.ERROR;
            }
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}

