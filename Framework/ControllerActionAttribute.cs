using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spartanprogramming.MVC
{
    [global::System.AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class ControllerActionAttribute : Attribute
    {
        public ControllerActionAttribute() { }
    }
}
