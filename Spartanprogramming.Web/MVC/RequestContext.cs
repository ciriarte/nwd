using System;
using System.Collections.Generic;
using System.Text;

namespace Spartanprogramming.Web.MVC
{
    public class RequestContext
    {
        public RequestContext(IHttpContext httpContext, RouteData routeData)
        {

        }

        public IHttpContext HttpContext {
            get
            {
                return _httpContext;
            }
            set
            {
                _httpContext = value;
            }
        }
        public RouteData RouteData {
            get
            {
                return _routeData;
            }
            set
            {
                _routeData = value;
            }
        }

        private IHttpContext _httpContext;
        private RouteData    _routeData;
    }
}
