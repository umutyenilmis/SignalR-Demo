using System;
using SignalR.Core.Service.DefaultServices.Interfaces;

namespace SignalR.Core.Service.DefaultServices
{
    public class ServiceBase : IService
    {
        protected internal void SetResultAsFail(int code, Exception exception)
        {
            this.Result = new ServiceResult(ServiceResultType.Fail, exception, code);
        }

        protected internal void SetResultAsFail(int code, string message)
        {
            this.Result = new ServiceResult(ServiceResultType.Fail, message, code);
        }

        protected void SetResultAsSuccess(int code, string message)
        {
            this.Result = new ServiceResult(ServiceResultType.Success, message, code);
        }

        protected void SetResultAsSuccess(int code)
        {
            this.Result = new ServiceResult(ServiceResultType.Success, code);
        }
        internal void SetResultAsSuccess()
        {
            this.Result = new ServiceResult(ServiceResultType.Success);
        }
        public ServiceResult Result { get; set; }   
    }
}