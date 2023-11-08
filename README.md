#   How to update checkbox state programmatically treeview xamarin

This section explains how to update checkbox state programmatically treeview xamarin.

#  Getting Started with Xamarin CheckBox (SfCheckBox)

##  Adding SfCheckBox reference
You can add SfCheckBox reference using one of the following methods:

##  Method 1: Adding SfCheckBox reference from nuget.org

Syncfusion Xamarin components are available in nuget.org. To add SfCheckBox to your project, open the NuGet package manager in Visual Studio, search for Syncfusion.Xamarin.Buttons, and then install it.

##  Method 2: Adding SfCheckBox reference from toolbox

Syncfusion also provides Xamarin Toolbox. Using this toolbox, you can drag the SfCheckBox control to the XAML page. It will automatically install the required NuGet packages and add the namespace to the page. To install Syncfusion Xamarin Toolbox, refer to Toolbox.

##  Method 3: Adding SfCheckBox assemblies manually from the installed location

If you prefer to manually reference the assemblies instead referencing from NuGet, add the following assemblies in respective projects.

#   Create a Simple SfCheckBox
The Xamarin CheckBox (SfCheckBox) control is configured entirely in C# code or by using XAML markup. The following steps explain how to create a SfCheckBox and configure its elements.

##  Add namespace for referred assemblies

**[XAML]**
```
xmlns:syncfusion="clr-namespace:Syncfusion.XForms.Buttons;assembly=Syncfusion.Buttons.XForms"
```
Refer SfCheckBox control with declared suffix name for Namespace

**[XAML]**

```
<ContentPage>
    <ContentPage.Content>
        <StackLayout>
              <syncfusion:SfCheckBox x:Name="checkBox"/>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

```
<StackLayout>
    <treeView:SfTreeView x:Name="treeView"
                         ItemsSource="{Binding Folders}"
                         ItemTemplateContextType="Node"
                         AutoExpandMode="AllNodesExpanded"
                         CheckedItems="{Binding CheckedItems}">
        <treeView:SfTreeView.Behaviors>
            <local:TreeViewBehavior/>
        </treeView:SfTreeView.Behaviors>
        <treeView:SfTreeView.HierarchyPropertyDescriptors>
            <TreeViewEngine:HierarchyPropertyDescriptor TargetType="{x:Type local:Folder}" ChildPropertyName="Files"/>
            <TreeViewEngine:HierarchyPropertyDescriptor TargetType="{x:Type local:File}" ChildPropertyName="SubFiles"/>
        </treeView:SfTreeView.HierarchyPropertyDescriptors>

        <treeView:SfTreeView.ItemTemplate>
            <DataTemplate>
                <Grid Padding="5">
                    <SfButtons:SfCheckBox x:Name="CheckBox" Text="{Binding Content.FileName}" IsChecked="{Binding IsChecked, Mode=TwoWay}"/>
                </Grid>
            </DataTemplate>
        </treeView:SfTreeView.ItemTemplate>
    </treeView:SfTreeView>
</StackLayout>
```

**[C#]**

```
 public class FileManagerViewModel
    {
        #region Fields
        private ObservableCollection<object> checkedItems;
        #endregion

        #region Properties
        public ObservableCollection<object> CheckedItems
        {
            get { return checkedItems; }
            set { this.checkedItems = value; }
        }

        public ObservableCollection<Folder> Folders { get; set; }
        #endregion

        #region Constructor
        public FileManagerViewModel()
        {
            this.Folders = GetFiles();
        }
        #endregion

        #region Method
        private ObservableCollection<Folder> GetFiles()
        {
            var nodeImageInfo = new ObservableCollection<Folder>();

            var doc = new Folder() { FileName = "Documents"};
            var download = new Folder() { FileName = "Downloads"};
            var mp3 = new Folder() { FileName = "Music"};
            var pictures = new Folder() { FileName = "Pictures"};
            var video = new Folder() { FileName = "Videos"};

            var pollution = new File() { FileName = "Environmental Pollution.docx"};
            var globalWarming = new File() { FileName = "Global Warming.ppt"};            

            var games = new File() { FileName = "Game.exe"};
            var tutorials = new File() { FileName = "Tutorials.zip"};
            var typeScript = new File() { FileName = "TypeScript.7z"};
            var uiGuide = new File() { FileName = "UI-Guide.pdf"};

            var song = new File() { FileName = "Gouttes"};

            var camera = new File() { FileName = "Camera Roll"};
            var stone = new File() { FileName = "Stone.jpg"};
            var wind = new File() { FileName = "Wind.jpg"};

            var img0 = new SubFile() { FileName = "WIN_20160726_094117.JPG"};
            var img1 = new SubFile() { FileName = "WIN_20160726_094118.JPG"};

            var video1 = new File() { FileName = "Naturals.mp4"};
            var video2 = new File() { FileName = "Wild.mpeg"};

            doc.Files = new ObservableCollection<File>
            {
                pollution,
                globalWarming
            };

            download.Files = new ObservableCollection<File>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.Files = new ObservableCollection<File>
            {
                song
            };

            pictures.Files = new ObservableCollection<File>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<SubFile>
            {
                img0,
                img1
            };

            video.Files = new ObservableCollection<File>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);

            checkedItems = new ObservableCollection<object>();
            checkedItems.Add(doc);
            checkedItems.Add(typeScript);
            checkedItems.Add(uiGuide);
            checkedItems.Add(img1);
            checkedItems.Add(song);

            return nodeImageInfo;
        }
        #endregion
    }
```
