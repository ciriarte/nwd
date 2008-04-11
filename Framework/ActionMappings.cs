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
    public class ActionMappings<TController> : IMappingStrategy<Uri, MethodInfo> where TController : Controller
    {
        static ActionMappings()
        {
            _actions = new Dictionary<String, MethodInfo>();
            Type type = typeof(TController);
            MethodInfo[] publicMethods = type.GetMethods();
            foreach (MethodInfo member in publicMethods)
            {
                Object[] attributes = member.GetCustomAttributes(true);
                if (attributes != null)
                {
                    foreach (Object item in attributes)
                    {
                        if (item is ControllerActionAttribute)
                        {
                            _actions.Add(String.Format("/{0}/{1}", type.Name.Replace("Controller", String.Empty), member.Name), member);
                        }
                    }   
                }
            }
        }

        public ActionMappings(TController controller)
        {
            _controller = controller;
        }

        #region IMappingStrategy<Uri> Members

        public MethodInfo Map(Uri url)
        {
            MethodInfo result = null;
            if (_actions.ContainsKey(url.PathAndQuery))
            {
                result = _actions[url.PathAndQuery];
                result.Invoke(_controller, null);   
            }
            return result;
        }

        #endregion

        private Object[] ParseArguments(NameValueCollection queryString, ParameterInfo[] parametersInfo)
        {
            ArrayList parameters = new ArrayList();
            foreach (ParameterInfo parameterInfo in parametersInfo)
            {
                if (parameterInfo.ParameterType == typeof(String))
                {
                    parameters.Add(queryString[parameterInfo.Name]);
                    continue;
                }
                if (parameterInfo.ParameterType == typeof(Int32))
                {
                    parameters.Add(Int32.Parse(queryString[parameterInfo.Name]));
                    continue;
                }
                if (parameterInfo.ParameterType == typeof(Int64))
                {
                    parameters.Add(Int64.Parse(queryString[parameterInfo.Name]));
                    continue;
                }
                if (parameterInfo.ParameterType == typeof(Single))
                {
                    parameters.Add(Single.Parse(queryString[parameterInfo.Name]));
                    continue;
                }
                if (parameterInfo.ParameterType == typeof(Double))
                {
                    parameters.Add(Single.Parse(queryString[parameterInfo.Name]));
                    continue;
                }
            }

            return parameters.ToArray();
        }

        static
        protected Dictionary<String, MethodInfo> _actions;
        private   TController                    _controller;
    }
}
