using AIStudio.Wpf.DemoPage.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DemoPage.Views
{
    public class ItemsDisplayViewModel : BindableBase
    {
        private IList<AvatarModel> _dataList;
        public IList<AvatarModel> DataList
        {
            get => _dataList; 
            set => SetProperty(ref _dataList, value);
        }
        public ItemsDisplayViewModel(Func<List<AvatarModel>> getDatAction)
        {
            Task.Run(() => DataList = getDatAction?.Invoke());
        }
    }
}