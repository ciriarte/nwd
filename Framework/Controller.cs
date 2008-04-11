using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Reflection;
using System.Collections.Generic;
using Spartanprogramming.MVC.Web;

namespace Spartanprogramming.MVC
{
    public class Controller
    {
        public Controller()
        {
            
        }

        virtual
        public void Execute(HttpContext context)
        {
            _context = context;
            _actions.Map(_context.Request.Url);
        }

        public HttpResponse Response
        {
            get { return _context.Response; }
        }

        public HttpRequest Request
        {
            get { return _context.Request; }
        }

        public void RenderView<TViewData>(String viewName, TViewData viewData)
        {
            _context.Items.Add("viewData", viewData);
            _context.RewritePath(_views.Map(viewName), false);
        }

        protected
        IMappingStrategy<Uri, MethodInfo> _actions = null;
        protected
        IMappingStrategy<String, String>  _views   = null;

        private HttpContext               _context;
    }
}
