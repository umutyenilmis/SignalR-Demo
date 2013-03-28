using System;
using Castle.DynamicProxy;
using SignalR.Core.Infrastructure.UoW;
using SignalR.Core.Service.DefaultServices;

namespace SignalR.Core.Infrastructure.Interceptors
{
    public class ServiceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                if (UnitOfWork.CurrentSession.Transaction.IsActive)
                    UnitOfWork.CurrentSession.Transaction.Rollback();

                //var logger = LogManager.GetLogger(invocation.Method.DeclaringType);
                //logger.Error(ex);

                var service = (ServiceBase)invocation.InvocationTarget;
                service.SetResultAsFail(500, ex);
            }
        }
    }
}