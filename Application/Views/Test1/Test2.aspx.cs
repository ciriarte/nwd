using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Application.Views.Test1
{
    public partial class Test2 : Spartanprogramming.MVC.Web.ViewPage<List<String>>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.DataSource = ViewData;
            ListBox1.DataBind();
        }
    }
}
