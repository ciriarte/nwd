using System;
using System.Collections.Generic;
using System.Text;

namespace Spartanprogramming.Web.MVC
{
    public class HttpRequest : IHttpRequest
    {
        String[] AcceptTypes { get { return null; } }
        String AnonymousId { get { return null; } }
        String ApplicationPath { get { return null; } }
        String AppRelativeCurrentExecutionFilePath { get { return null; } }
        Byte[] BinaryRead(Int32 count) { return null; }
        System.Web.HttpBrowserCapabilities Browser { get { return null; } }
        System.Web.HttpClientCertificate ClientCertificate { get { return null; } }
        Encoding ContentEncoding;
    }
}
