using Syncfusion.TreeView.Engine;
using Syncfusion.XForms.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class TreeViewBehavior : Behavior<SfTreeView>
    {
        #region Fields

        SfTreeView TreeView;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(SfTreeView bindable)
        {
            base.OnAttachedTo(bindable);

            TreeView = bindable;
            TreeView.Loaded += TreeView_Loaded;
        }

        protected override void OnDetachingFrom(SfTreeView bindable)
        {
            base.OnDetachingFrom(bindable);
            TreeView.Loaded -= TreeView_Loaded;
            TreeView = null;
        }
        #endregion

        #region Methods

        private void TreeView_Loaded(object sender, TreeViewLoadedEventArgs e)
        {
            UpdateCheckBoxState();
            TreeView.CheckBoxMode = CheckBoxMode.Recursive;
        }

        private void UpdateCheckBoxState()
        {
            var checkedNodes = TreeView.GetCheckedNodes();
            foreach (var node in checkedNodes)
            {
                //Update child nodes based on parent's checked state.
                if (node.ParentNode == null && node.HasChildNodes)
                {
                    setChildChecked(node);
                }

                //Update parent node based on child's checked state.
                else if (node.ParentNode != null)
                {
                    if (node.ParentNode.ChildNodes.All(x => x.IsChecked == true))
                    {
                        node.ParentNode.IsChecked = true;
                    }
                    else node.ParentNode.IsChecked = null;
                }

            }
        }

        private void setChildChecked(TreeViewNode node)
        {
            foreach (var child in node.ChildNodes)
            {
                child.IsChecked = true;
                if (child.HasChildNodes)
                {
                    setChildChecked(child);
                }
            }
        }
        #endregion
    }
}
