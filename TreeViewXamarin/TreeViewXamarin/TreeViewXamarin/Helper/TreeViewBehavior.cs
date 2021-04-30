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
                if (node.ParentNode == null && node.HasChildNodes)
                {
                    //Update child nodes based on parent's checked state.
                    SetChildChecked(node);
                }

                else
                {
                    //Update parent node based on child's checked state.
                    SetParentChecked(node);
                }
            }
        }

        private void SetChildChecked(TreeViewNode node)
        {
            foreach (var child in node.ChildNodes)
            {
                child.IsChecked = true;
                if (child.HasChildNodes)
                {
                    SetChildChecked(child);
                }
            }
        }

        private void SetParentChecked(TreeViewNode node)
        {
            if (node.ParentNode == null) return;

            if (node.ParentNode.ChildNodes.All(x => x.IsChecked == true))
                node.ParentNode.IsChecked = true;

            else node.ParentNode.IsChecked = null;

            if(node.ParentNode != null)
            {
                SetParentChecked(node.ParentNode);
            }
        }
        #endregion
    }
}
