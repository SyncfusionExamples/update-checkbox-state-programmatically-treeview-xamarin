using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TreeViewXamarin
{
    [Preserve(AllMembers = true)]
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
}