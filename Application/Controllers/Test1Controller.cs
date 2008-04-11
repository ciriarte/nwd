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

using Spartanprogramming.MVC;
using System.Collections.Generic;

namespace Application
{
    public class Test1Controller : Controller
    {
        public Test1Controller()
        {
            _actions = new ActionMappings<Test1Controller>(this);
            _views   = new ViewMappings<Test1Controller>(this);
        }

        [ControllerAction]
        public void DoSomething()
        {
            List<String> a = new List<string>();
            a.Add("Hola");
            a.Add("Adios");
            RenderView("Test2", a);
        }
    }
}
