using Accelerider.Extensions.Mvvm;
using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using DryIoc;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Threading.Tasks;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseEditWithOptionViewModel<TData, Option> : Prism.Mvvm.BindableBase, IBaseEditWithOptionViewModel<Option> where TData : class, IIsChecked
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

        private TData _data;
        public TData Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        public Option Options { get; set; }

        public string Identifier { get; set; } = LocalSetting.RootWindow;
        public string Area { get; set; }

        protected IDataProvider _dataProvider { get { return ContainerLocator.Current.Resolve<IDataProvider>(); } }
        protected IUserData _userData { get { return ContainerLocator.Current.Resolve<IUserData>(); } }
        protected ChildWindow View { get; set; }

        public virtual async Task OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            View = sender as ChildWindow;

            await GetData(Options);
        }

        public virtual Task OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            return Task.CompletedTask;
        }

        protected virtual async Task GetData(Option option)
        {
            try
            {
                ShowWait();

                if (option is string id)
                {
                    var result = await _dataProvider.GetData<TData>($"/{Area}/{typeof(TData).Name.Replace("DTO", "")}/GetTheData", JsonConvert.SerializeObject(new { id = id }));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Data = result.Data;
                }
                else if (option is TData data)
                {
                    Data = data;
                }
                else
                {
                    Data = System.Activator.CreateInstance<TData>();
                }
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

        protected virtual async Task<bool> SaveData()
        {
            try
            {
                ShowWait();
                var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(TData).Name.Replace("DTO", "")}/SaveData", Data.ToJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
                return false;
            }
            finally
            {
                HideWait();
            }
        }

        public virtual async Task<bool> ValidationAsync()
        {
            if (!string.IsNullOrEmpty(Data?.Error))
            {
                MessageBox.Error(Data.Error);
                return false;
            }
            else
            {
                return await SaveData();
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


        protected BaseEditWithOptionViewModel()
        {

        }

        ~BaseEditWithOptionViewModel()
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

    public interface IBaseEditWithOptionViewModel<Option> : IViewLoadedAndUnloadedAwareAsync
    {
        Option Options { get; set; }
        string Identifier { get; set; }
        string Area { get; set; }
        Task<bool> ValidationAsync();
    }
}
