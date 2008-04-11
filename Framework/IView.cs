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

namespace Spartanprogramming.MVC
{
    public interface IView
    {
        Object ViewData {get;}
    }

    public interface IView<TViewData> : IView
    {
        new TViewData ViewData { get; }
    }
}
