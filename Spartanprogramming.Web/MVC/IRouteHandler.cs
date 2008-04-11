using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Spartanprogramming.Web.MVC
{
    interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}
