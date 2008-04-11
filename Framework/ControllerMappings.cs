using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections;

namespace Spartanprogramming.MVC
{
    public class ControllerMappings : IMappingStrategy<HttpContext, Controller>
    {
        public ControllerMappings()
        {
            _controllers = new Dictionary<String, Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(Controller)))
                    {
                        _controllers.Add(String.Format("{0}", type.Name), type);
                    }
                }
            }
        }

        #region IMappingStrategy<Uri> Members

        public Controller Map(HttpContext context)
        {
            Controller controller = null;
            String controllerName = ParseControllerName(context.Request.RawUrl);
            if (_controllers.ContainsKey(controllerName))
	        {
                controller = Activator.CreateInstance(_controllers[controllerName]) as Controller;
	        }
            return controller;
        }

        #endregion

        private String ParseControllerName(String pathAndQuery)
        {
            String controller = pathAndQuery.Split('/')[1];
            return String.Format("{0}Controller", controller);
        }

        private Dictionary<String, Type> _controllers;
    }
}
