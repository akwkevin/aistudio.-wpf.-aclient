using AIStudio.Core.Models;
using AutoMapper;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace AIStudio.Wpf.BasePage.Models
{
    [AutoMap(typeof(AMenuItem))]
    public class _3DItemData
    {
        [JsonIgnore]
        public Control Content { get; set; }
        public string Type { get; set; }//序列化后重构控件使用
        public string Glyph { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public string WpfCode { get; set; }
    }

    public class User3DData : Prism.Mvvm.BindableBase
    {
        private ObservableCollection<_3DItemData> _data = new ObservableCollection<_3DItemData>();
        public ObservableCollection<_3DItemData> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }
    }
}
