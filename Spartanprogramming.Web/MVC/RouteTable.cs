using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Spartanprogramming.Web.MVC
{
    public class RouteTable
    {
        static
        public RouteCollection Routes {
            get
            {
                return _routes;
            }
        }

        private static RouteCollection _routes = new RouteCollection();
    }
}
