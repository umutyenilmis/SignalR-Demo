using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.Windsor;

namespace SignalR.Web.Infrastructure.Mvc
{
    public class WindsorControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            controllerName = controllerName.ToLowerInvariant() + "controller";

            var hasComponent = Container.Kernel.HasComponent(controllerName);

            if (!hasComponent)
                throw new HttpException(404, string.Empty);

            return Container.Resolve<IController>(controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            Container.Release(controller);
        }

        private static IWindsorContainer Container
        {
            get { return ((IContainerAccessor)HttpContext.Current.ApplicationInstance).Container; }
        }
    }
}