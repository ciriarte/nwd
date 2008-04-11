using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Spartanprogramming.Web.MVC
{
    public class ViewMappings<TController> : ConfigurationSection, IMappingStrategy<String, String>
    {
        public ViewMappings(TController controller)
        {
            _controller = controller;
        }

        #region IMappingStrategy<String> Members

        virtual
        public String Map(String viewName)
        {
            return String.Format("/views/{0}/{1}.aspx",
                                 typeof(TController).Name.ToLower().Replace("controller", String.Empty),
                                 viewName);
        }

        #endregion

        private TController _controller;
    }
}
