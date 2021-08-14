using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Mvvm;
using System;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseEditViewModel<T> : BindableBase where T : class, IIsChecked
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
            //get { return _data; }
            //set
            //{
            //    SetProperty(ref _data, value);
            //}

            get { return _data; }
            set
            {
                if (value != _data)
                {
                    _data = value;
                    RaisePropertyChanged("Data");
                }
            }

        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }

        protected IDataProvider _dataProvider { get { return ContainerLocator.Current.Resolve<IDataProvider>(); } }
        protected IUserData _userData { get { return ContainerLocator.Current.Resolve<IUserData>(); } }

        public BaseEditViewModel(T data, string area, string identifier, string title = "编辑表单")
        {
            Data = data;
            Title = title;
            Area = area;      
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
                throw ex;
            }
            finally
            {
                HideWait();
            }
        }

        protected void ShowWait()
        {
            var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
            control.WaitInfo = "正在获取数据";
        }

        protected void HideWait()
        {
            Util.Controls.WindowBase.HideWaiting(Identifier);
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
