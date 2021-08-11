using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class BuildCodeEditWindowViewModel : BindableBase
    {
        private List<BuildCode> _data;
        public List<BuildCode> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        private BuildCode _selectedData;
        public BuildCode SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _areaName;
        public string AreaName
        {
            get { return _areaName; }
            set
            {
                if (SetProperty(ref _areaName, value))
                {
                    UpdateAreaName();
                }
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;

        private bool _isCover;
        public bool IsCover
        {
            get { return _isCover; }
            set
            {
                SetProperty(ref _isCover, value);
            }
        }

        private ICommand _oKCommand;
        public new ICommand OKCommand
        {
            get
            {
                return this._oKCommand ?? (this._oKCommand = new CanExecuteDelegateCommand(() => this.OK(), () => Data != null && Data.Count(p => p.IsChecked) > 0));
            }
        }



        private ICommand _saveTempCommand;
        public ICommand SaveTempCommand
        {
            get
            {
                return this._saveTempCommand ?? (this._saveTempCommand = new CanExecuteDelegateCommand(() => this.SaveTemp(), () => Data != null && Data.Count(p => p.IsChecked) > 0));
            }
        }



        public BuildCodeEditWindowViewModel(List<BuildCode> data, string areaName, string identifier, string title = "编辑表单")
        {
            Data = data;
            SelectedData = Data.FirstOrDefault();
            AreaName = areaName;
            Identifier = identifier;
            Title = title;
        }

        public void UpdateAreaName()
        {
            foreach (var item in Data)
            {
                foreach (var subitem in item.SubBuildCode)
                {
                    subitem.Path = subitem.TempPath.Replace("areaName", AreaName);
                }
            }
        }

        private void OK()
        {
            foreach (var item in Data.Where(p => p.IsChecked))
            {
                foreach (var subitem in item.SubBuildCode.Where(p => p.IsChecked))
                {
                    if (IsCover || !File.Exists(subitem.Path))
                        FileHelper.WriteTxt(subitem.Code, subitem.Path, Encoding.UTF8, FileMode.Create);
                }
            }
        }

        private void SaveTemp()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                var path = folder.SelectedPath;
                foreach (var item in Data.Where(p => p.IsChecked))
                {
                    foreach (var subitem in item.SubBuildCode.Where(p => p.IsChecked))
                    {
                        var file = $"{path}\\{subitem.FileName}.{subitem.Suffix}";
                        if (IsCover || !File.Exists(file))
                            FileHelper.WriteTxt(subitem.Code, file, Encoding.UTF8, FileMode.Create);
                    }
                }

                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }
    }
}
