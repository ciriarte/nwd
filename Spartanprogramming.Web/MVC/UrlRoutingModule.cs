using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Reflection;
using System.Collections.Specialized;

namespace Spartanprogramming.Web.MVC
{
    class UrlRoutingModule : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Demultiplex);
        }

        public void Dispose()
        {

        }

        #endregion

        public void Demultiplex(Object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;

            // Find the route that adheres best to the request.
            Route route = FindBestRoute(app.Request.Url);

            IRouteHandler routeHandler = Activator.CreateInstance(route.RouteHandler, false) as IRouteHandler;
            
            RequestContext requestContext = new RequestContext(new Spartanprogramming.Web.MVC.HttpContext(app.Context),
                                                               new RouteData());

            IHttpHandler httpHandler = routeHandler.GetHttpHandler(requestContext);
        }

        private Route FindBestRoute(Uri uri)
        {
            String[] segments = uri.Segments;
            return RouteTable.Routes.Find(route => route.Url.Split('/').Length == segments.Length - 1);
        }
    }
}
