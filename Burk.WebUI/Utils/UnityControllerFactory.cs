using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Burk.WebUI.Utils
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        IUnityContainer container;

        public IUnityContainer Container { get { return container; } }

        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext reqContext, Type controllerType)
        {
            IController controller;
            if (controllerType == null)
                throw new HttpException(
                        404, String.Format(
                            "The controller for path '{0}' could not be found or it does not implement IController.",
                        reqContext.HttpContext.Request.Path));

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(
                        string.Format(
                            "Type requested is not a controller: {0}",
                            controllerType.Name),
                            "controllerType");

            try
            {
                controller = container.Resolve(controllerType)
                                as IController;
                (controller as Controller).ActionInvoker = new UnityActionInvoker(container);
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format(
                                        "Error resolving controller {0}",
                                        controllerType.Name), ex);
            }

            return controller;
        }
    }

    public class UnityActionInvoker : ControllerActionInvoker
    {
        IUnityContainer container;

        public IUnityContainer Container { get { return container; } }

        public UnityActionInvoker(IUnityContainer container)
        {
            this.container = container;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters.AuthorizationFilters)
            {
                container.BuildUp(filter.GetType(), filter);
            }
            return filters;
        }
    }
}