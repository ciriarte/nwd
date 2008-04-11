using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Spartanprogramming.Web.MVC
{
    public class Route
    {
        public Route() {
            
        }

        public Route(String url, Type routeHandler) {
            _url          = url;
            _routeHandler = routeHandler;
        }

        public Route(String url, Object defaults, Type routeHandler)
        {
            _url = url;
            _defaults = defaults;
            _routeHandler = routeHandler;
        }

        public String Url {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
        public Object Defaults {
            get
            {
                return _defaults;
            }
            set
            {
                _defaults = value;
            }
        }
        public Type RouteHandler {
            get
            {
                return _routeHandler;
            }
            set
            {
                _routeHandler = value;
            }
        }

        private String _url;
        private Object _defaults;
        private Type   _routeHandler;
    }
}
