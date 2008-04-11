using System;
using System.Collections.Generic;
using System.Text;

namespace Spartanprogramming.Web.MVC
{
    public class HttpContext : IHttpContext
    {
        public HttpContext(System.Web.HttpContext httpContext) {
            _httpContext = httpContext;
        }

        #region IHttpContext Members

        public IHttpResponse Response
        {
            get { return _httpContext.Response as IHttpResponse; }
        }

        public IHttpRequest Request
        {
            get { return _httpContext.Request as IHttpRequest; }
        }

        public void RewritePath(string path)
        {
            _httpContext.RewritePath(path);
        }

        public void RewritePath(string path, bool rebaseClientPath)
        {
            _httpContext.RewritePath(path, rebaseClientPath);
        }

        public void RewritePath(string filePath, string pathInfo, string queryString)
        {
            _httpContext.RewritePath(filePath, pathInfo, queryString);
        }

        public void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath)
        {
            _httpContext.RewritePath(filePath, pathInfo, queryString, setClientFilePath);
        }

        public System.Collections.IDictionary Items
        {
            get { return _httpContext.Items; }
        }

        public System.Security.Principal.IPrincipal User
        {
            get { return _httpContext.User; }
        }

        public System.Web.SessionState.HttpSessionState Session
        {
            get { return _httpContext.Session; }
        }

        #endregion

        private System.Web.HttpContext _httpContext;
    }
}
