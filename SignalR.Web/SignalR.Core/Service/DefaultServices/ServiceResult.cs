using System;

namespace SignalR.Core.Service.DefaultServices
{
    public class ServiceResult
    {
        public ServiceResult()
        {

        }
        public ServiceResult(ServiceResultType resultType)
        {
            ResultType = resultType;
        }
        public ServiceResult(ServiceResultType resultType, int code)
        {
            ResultType = resultType;
            Code = code;
        }

        public ServiceResult(ServiceResultType resultType, string message, int code)
        {
            ResultType = resultType;
            Message = message;
            Code = code;
        }

        public ServiceResult(ServiceResultType resultType, Exception exception, string message, int code)
        {
            ResultType = resultType;
            Exception = exception;
            Message = message;
            Code = code;
        }

        public ServiceResult(ServiceResultType resultType, Exception exception, int code)
        {
            ResultType = resultType;
            Exception = exception;
            Code = code;
        }

        public ServiceResultType ResultType { get; private set; }
        public Exception Exception { get; private set; }
        public int Code { get; private set; }
        public string Message { get; private set; }


    }
}