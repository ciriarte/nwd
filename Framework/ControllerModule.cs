using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Reflection;
using System.Collections.Specialized;

namespace Spartanprogramming.MVC
{
    class ControllerModule : IHttpModule
    {
        #region IHttpModule Members

        public ControllerModule()
        {
            _controllerMappings = new ControllerMappings();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Demultiplex);
        }

        void context_MapRequestHandler(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
        }


        public void Dispose()
        {

        }

        #endregion

        public void Demultiplex(Object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            Controller controller = _controllerMappings.Map(app.Context);
            controller.Execute(app.Context);
        }

        private IMappingStrategy<HttpContext, Controller>   _controllerMappings;
    }
}
