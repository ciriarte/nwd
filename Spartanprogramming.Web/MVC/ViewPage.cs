using System;
using System.Collections.Generic;
using System.Text;

namespace Spartanprogramming.Web.MVC
{
    public class ViewPage<TViewData> : System.Web.UI.Page, IView<TViewData>
    {
        #region IView<TViewData> Members

        public TViewData ViewData
        {
            get { return (TViewData)Context.Items["viewData"]; }
        }

        #endregion

        #region IView Members

        Object IView.ViewData
        {
            get { return _viewData; }
        }

        #endregion

        protected TViewData _viewData;
    }
}
