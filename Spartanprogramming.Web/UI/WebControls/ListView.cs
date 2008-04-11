using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Collections;
using System.Web;
using System.Security.Permissions;

namespace Spartanprogramming.Web.UI.WebControls
{
    [ParseChildren(true)]
    public class ListView : DataBoundControl, INamingContainer
    {
        [TemplateInstance(TemplateInstance.Single)]
        [TemplateContainer(typeof(ListViewItem))]
        public ITemplate LayoutTemplate { get; set; }

        [TemplateInstance(TemplateInstance.Single)]
        [TemplateContainer(typeof(ListViewItem))]
        public ITemplate EmptyDataTemplate { get; set; }

        [TemplateContainer(typeof(ListViewItem))]
        public ITemplate GroupTemplate { get; set; }

        [TemplateContainer(typeof(ListViewItem))]
        public ITemplate AlternatingGroupTemplate { get; set; }

        [TemplateContainer(typeof(ListViewItem))]
        public ITemplate AlternatingItemTemplate { get; set; }

        [TemplateContainer(typeof(ListViewItem))]
        public ITemplate ItemTemplate { get; set; }

        [DefaultValue("groupPlaceholder")]
        public String GroupPlaceholderID {
            get
            {
                return _groupPlaceholderID;
            }
            set
            {
                _groupPlaceholderID = value;
            }
        }

        [DefaultValue("itemPlaceholder")]
        public String ItemPlaceholderID {
            get
            {
                return _itemPlaceholderID;
            }
            set
            {
                _itemPlaceholderID = value;
            }
        }

        public IList<ListViewItem> Items
        {
            get
            {
                return _items as IList<ListViewItem>;
            }
        }

        public Int32 GroupItemCount {
            get
            {
                return _groupItemCount;
            }
            set
            {
                _groupItemCount = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            RenderContents(writer);
        }

        protected override void CreateChildControls()
        {
            if (_items != null) {
                if (LayoutTemplate != null) {
                    LayoutTemplate.InstantiateIn(this);
                    InstantiateTemplates();
                }
            } else {
                if (EmptyDataTemplate != null) {
                    EmptyDataTemplate.InstantiateIn(this);
                }
            }
        }

        private void InstantiateTemplates()
        {
            PlaceHolder groupPlaceholder;
            PlaceHolder itemPlaceholder;
            if (GroupTemplate != null && _groupItemCount > 1) {
                groupPlaceholder = FindControl(_groupPlaceholderID) as PlaceHolder;
                if (groupPlaceholder != null) {
                    CreateGroupedItems(groupPlaceholder);
                } else {
                    throw new InvalidOperationException(String.Format("No {0} declared to instantiate GroupTemplate",
                                                        _groupPlaceholderID));
                }
            } else { // No grouping template
                itemPlaceholder = FindControl(_itemPlaceholderID) as PlaceHolder;
                if (itemPlaceholder == null) {
                    throw new InvalidOperationException(String.Format("No {0} declared to instantiate ItemTemplate",
                                                        _itemPlaceholderID));
                }
                CreateGroupedItems(null);
            }
        }

        private void CreateGroupedItems(PlaceHolder groupPlaceholder)
        {
            PlaceHolder itemPlaceholder = FindControl(_itemPlaceholderID) as PlaceHolder;
            foreach (var item in _items)
            {
                Int32 groupCount = 0;
                if (groupPlaceholder != null && (item.Index) % _groupItemCount == 0)
                {
                    ListViewItem groupItem = new ListViewItem(++groupCount);
                    if (AlternatingGroupTemplate != null && item.Index % 2 == 0)
                    {
                        AlternatingGroupTemplate.InstantiateIn(groupItem);
                    }
                    else
                    {
                        GroupTemplate.InstantiateIn(groupItem);
                    }
                    groupPlaceholder.Controls.Add(groupItem);
                    itemPlaceholder = groupItem.FindControl(_itemPlaceholderID) as PlaceHolder;
                }
                if (AlternatingItemTemplate != null && item.Index % 2 == 0)
                {
                    AlternatingItemTemplate.InstantiateIn(item);
                }
                else
                {
                    ItemTemplate.InstantiateIn(item);
                }
                itemPlaceholder.Controls.Add(item);
                if (_databinded)
                {
                    item.DataBind();
                }
            }
        }

        protected override void PerformDataBinding(IEnumerable retrievedData)
        {
            Int32 count = 0;
            _items = new List<ListViewItem>();
            if (retrievedData != null)
            {
                foreach (var dataitem in retrievedData)
                {
                    ListViewItem listItem = new ListViewItem(count++);
                    listItem.DataItem = dataitem;
                    _items.Add(listItem);
                }   
            }
            _databinded = true;
        }

        private List<ListViewItem> _items;
        private String             _groupPlaceholderID = "groupPlaceholder";
        private String             _itemPlaceholderID  = "itemPlaceholder";
        private Int32              _groupItemCount     = 2;
        private Boolean            _databinded         = false;
    }
}
