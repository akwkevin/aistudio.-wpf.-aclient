using AIStudio.Core;
using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    class Common_FormConfigQueryEditViewModel : Prism.Mvvm.BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private bool _disabled;
        public bool Disabled
        {
            get { return _disabled; }
            set
            {
                SetProperty(ref _disabled, value);
            }
        }

        private ExpandoObject _data;
        public ExpandoObject Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        public ObservableCollection<EditFormItem> EditFormItems
        {
            get; private set;
        } = new ObservableCollection<EditFormItem>();

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }
        protected string Name { get; set; }

        protected IDataProvider _dataProvider { get { return ContainerLocator.Current.Resolve<IDataProvider>(); } }
        protected IUserData _userData { get { return ContainerLocator.Current.Resolve<IUserData>(); } }

        public Common_FormConfigQueryEditViewModel(IEnumerable<EditFormItem> editFormItems, ExpandoObject data, string area, string name, string identifier, string title = "编辑表单")
        {
            Data = data;
            Title = title;
            Area = area;
            Name = name;

            EditFormItems = new ObservableCollection<EditFormItem>(editFormItems);

            if (Data == null)
            {
                InitData();
            }
            else
            {
                GetData(Data);
            }
        }

        protected virtual void InitData()
        {
            Data = System.Activator.CreateInstance<ExpandoObject>();

            BaseControlItem.ObjectToList(Data, EditFormItems);
        }

        protected virtual async void GetData(ExpandoObject para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<ExpandoObject>($"/{Area}/{Name}/GetTheData", JsonConvert.SerializeObject(new { id = ((dynamic)para).Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;

                BaseControlItem.ObjectToList(Data, EditFormItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                HideWait();
            }
        }

        protected void ShowWait()
        {
            WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");
        }

        protected void HideWait()
        {
            WindowBase.HideWaiting(Identifier);
        }


        protected Common_FormConfigQueryEditViewModel()
        {

        }

        ~Common_FormConfigQueryEditViewModel()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //执行基本的清理代码
            }
        }
    }
}
