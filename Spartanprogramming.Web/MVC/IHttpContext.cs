using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Security.Principal;
using System.Web.SessionState;

namespace Spartanprogramming.Web.MVC
{
    public interface IHttpContext
    {
        IHttpResponse    Response { get; }
        IHttpRequest     Request { get; }
        IDictionary      Items { get; }
        IPrincipal       User { get; }
        HttpSessionState Session { get; }
        void RewritePath(String url, bool endResponse);
    }
}
