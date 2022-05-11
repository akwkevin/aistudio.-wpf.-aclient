using AIStudio.Core;
using Dataforge.PrismAvalonExtensions.ViewModels;
using AIStudio.Wpf.D_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Util.Controls;
using Util.Controls.DialogBox;
using System.Threading.Tasks;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_NoticeViewModel : BaseWindowViewModel<D_NoticeDTO>
    {
        private string _status = "processing";
        public string Status
        {
            get { return _status; }
            set
            {
                if (SetProperty(ref _status, value))
                {
                    GetData();
                }
            }
        }

        protected IOperator _operator { get; }

        public D_NoticeViewModel():base("D_Manage", typeof(D_NoticeEditViewModel), typeof(D_NoticeEdit))
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
        }

        public override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                int status;
                if (Status == "processing")
                {
                    status = 0;
                }
                else if (Status == "finish")
                {
                    status = 1;
                }
                else
                {
                    status = 2;
                }

                var data = new
                {
                    PageIndex = Pagination.PageIndex,
                    PageRows = Pagination.PageRows,
                    SortField = Pagination.SortField,
                    SortType = Pagination.SortType,
                    Search = new
                    {
                        userId = _operator.UserId,
                        status = status,
                    }
                };

                var result = await _dataProvider.GetData<List<D_NoticeDTO>>("/D_Manage/D_Notice/GetDataList", JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<D_NoticeDTO>(result.Data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        public static async Task<BaseDialogResult> EditShow(D_NoticeDTO para, string identifier)
        {
            var viewmodel = new D_NoticeEditViewModel(para, "D_Manage", identifier);
            return await EditShow(viewmodel, identifier);
        }
        public static async Task<BaseDialogResult> EditShow(D_NoticeEditViewModel viewmodel, string identifier)
        {
            var dialog = new D_NoticeEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, identifier);
            return res;
        }

        protected override async void Edit(D_NoticeDTO para = null)
        {
            var viewmodel = new D_NoticeEditViewModel(para, "D_Manage", Identifier);
            var res = await EditShow(viewmodel, Identifier);
            if (res == BaseDialogResult.OK || res == BaseDialogResult.Other1)
            {
                try
                {
                    ShowWait();
                    if (res == BaseDialogResult.Other1)
                    {
                        viewmodel.Data.Status = 0;
                    }
                    else
                    {
                        viewmodel.Data.Status = 1;
                    }

                    viewmodel.Data.CreatorName = $"^{_operator?.Property?.UserName}^";
                    viewmodel.Data.CreatorId = $"^{_operator?.Property?.Id}^";
                    if (viewmodel.Data.Mode == 1)
                    {
                        viewmodel.Data.AnyId = "^" + string.Join("^", viewmodel.SelectedUsers.Select(p => p.value)) + "^";
                    }
                    else if (viewmodel.Data.Mode == 2)
                    {
                        viewmodel.Data.AnyId = "^" + string.Join("^", viewmodel.SelectedRoles.Select(p => p.value)) + "^";
                    }

                    var result = await _dataProvider.GetData<AjaxResult>($"/D_Manage/D_Notice/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
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
            else
            {
                if (string.IsNullOrEmpty(viewmodel.Data.UserId))
                {
                    GetData();
                }
            }
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
