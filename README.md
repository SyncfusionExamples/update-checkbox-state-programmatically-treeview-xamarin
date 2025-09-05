# update-checkbox-state-programmatically-treeview-xamarin

This repository demonstrates how to update the checkbox state of nodes programmatically in the Syncfusion Xamarin.Forms TreeView control. The sample shows how to check or uncheck TreeView nodes in response to application logic, user actions outside the TreeView, or ViewModel changes. It covers how to manipulate the checked state directly from code.

## Sample

### Behaviour

```csharp
public class TreeViewBehavior : Behavior<SfTreeView>
{
    SfTreeView TreeView;
 
   protected override void OnAttachedTo(SfTreeView bindable)
    {
        base.OnAttachedTo(bindable);
 
        TreeView = bindable;
        TreeView.Loaded += TreeView_Loaded;
    }
 
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
}
```

## Requirements to run the demo
Visual Studio 2017 or Visual Studio for Mac.
Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.