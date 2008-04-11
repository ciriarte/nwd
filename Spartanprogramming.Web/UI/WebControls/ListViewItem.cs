using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;

namespace Spartanprogramming.Web.UI.WebControls
{
    [ParseChildren(true)]
    public class ListViewItem : Control, IDataItemContainer
    {
        public ListViewItem(Int32 itemIndex)
        {
            _itemIndex = itemIndex;
        }

        #region IDataItemContainer Members

        public virtual object DataItem
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public int Index
        {
            get { return _itemIndex; }
        }

        int IDataItemContainer.DataItemIndex
        {
            get { return _itemIndex; }
        }

        int IDataItemContainer.DisplayIndex
        {
            get { return _itemIndex; }
        }

        #endregion

        private Object _data;
        private Int32  _itemIndex;
    }
}
