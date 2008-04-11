using System;
using System.Collections.Generic;
using System.Text;

namespace Spartanprogramming.Web.MVC
{
    [global::System.AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class ControllerActionAttribute : Attribute
    {
        public ControllerActionAttribute() { }
    }
}
