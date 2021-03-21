using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.EFCore.DTOModels;
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
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }

        protected bool NeedUserData { get; set; } = false;

        protected IDataProvider _dataProvider { get; }
        protected IUserData _userData { get; }

        public BaseEditViewModel(T data, string area, string identifier, string title = "编辑表单",  bool needUserData = false)
        {
            Data = data;
            Title = title;
            Area = area;
            NeedUserData = needUserData;

            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();
            if (NeedUserData)
            {
                _userData = ContainerLocator.Current.Resolve<IUserData>();
            }          
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
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data = result.ResponseItem;
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
