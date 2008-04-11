using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Collections.Generic;
using Spartanprogramming.Web;
using System.Security.Principal;

namespace Spartanprogramming.Web.MVC
{
    public class Controller
    {
        virtual
        public void Execute(IHttpContext context)
        {
            _context = context;
        }

        public IHttpResponse Response
        {
            get { return _context.Response; }
        }

        public IHttpRequest Request
        {
            get { return _context.Request; }
        }

        public void RenderView<TViewData>(String viewName, TViewData viewData)
        {
            _context.Items.Add("viewData", viewData);
            _context.RewritePath(_views.Map(viewName), false);
        }

        public void RenderView(String viewName)
        {
            _context.RewritePath(_views.Map(viewName), false);
        }

        public void RedirectToAction(String action)
        {
            Response.Redirect(action, true);
        }

        public IHttpContext Context {
            get
            {
                return _context;
            }
        }

        public IPrincipal User {
            get
            {
                return _context.User;
            }
        }

        protected
        IMappingStrategy<Uri, MethodInfo> _actions = null;
        protected
        IMappingStrategy<String, String>  _views   = null;

        private IHttpContext              _context;
    }
}