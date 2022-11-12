using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using Newtonsoft.Json;
using Prism.Ioc;
using System;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseEditViewModel<T> : Prism.Mvvm.BindableBase where T : class, IIsChecked
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

        private T _data;
        public T Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }

        protected IDataProvider _dataProvider;
        protected IUserData _userData { get { return ContainerLocator.Current.Resolve<IUserData>(); } }

        public BaseEditViewModel(T data, string area, string identifier, string title = "编辑表单", bool autoInit = true)
        {
            Data = data;
            Title = title;
            Area = area;
            InitDataProvider();

            if (autoInit)
            {
                if (Data == null)
                {
                    InitData();
                }
                else
                {
                    GetData(Data);
                }
            }
        }

        protected virtual void InitDataProvider()
        {
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();
        }

        protected virtual void InitData()
        {
            Data = System.Activator.CreateInstance<T>();
        }

        protected virtual async void GetData(T para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<T>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
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


        protected BaseEditViewModel()
        {

        }

        ~BaseEditViewModel()
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
