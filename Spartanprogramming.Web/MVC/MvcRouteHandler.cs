using System;
using System.Collections.Generic;
using System.Text;

namespace Spartanprogramming.Web.MVC
{
    public class MvcRouteHandler : IRouteHandler
    {
        #region IRouteHandler Members

        public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return null;
        }

        #endregion
    }
}
