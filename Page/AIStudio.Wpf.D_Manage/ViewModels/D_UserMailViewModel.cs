using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.D_Manage.Views;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMailViewModel : BaseWindowViewModel<D_UserMailDTO>
    {
        private int _indexType;
        public int IndexType
        {
            get { return _indexType; }
            set
            {
                if (_indexType != value)
                {
                    _indexType = value;
                    RaisePropertyChanged("IndexType");
                }
            }
        }

       
        

        private IOperator _operator { get; }

        public D_UserMailViewModel(int indexType, string identifier) :base("D_Manage", typeof(D_UserMailEditViewModel), typeof(D_UserMailEdit))
        {
            _operator= ContainerLocator.Current.Resolve<IOperator>();
            IndexType = indexType;
            Identifier = identifier;
        }

        protected override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        public D_UserMailViewModel(string[] id)//无效参数，做个标记
        {
      
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", Pagination.PageIndex.ToString());
                data.Add("PageRows", Pagination.PageRows.ToString());
                data.Add("SortField", Pagination.SortField ?? "Id");
                data.Add("SortType", Pagination.SortType);
                data.Add("keyword", KeyWord ?? "");
                data.Add("condition", ConditionItem != null ? ConditionItem.Tag.ToString() : "");
                if (this.IndexType == 1)
                {
                    data.Add("userId", _operator.Property?.Id);
                }
                if (this.IndexType == 2 || this.IndexType == 3)
                {
                    data.Add("creatorId", _operator.Property?.Id);
                }
                if (this.IndexType == 3)
                {
                    data.Add("draft", "True");
                }

                var result = await _dataProvider.GetData<List<D_UserMailDTO>>($"/D_Manage/D_UserMail/GetDataList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<D_UserMailDTO>(result.ResponseItem);
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

        public static async Task<BaseDialogResult> EditShow(D_UserMailDTO para, string identifier)
        {
            var viewmodel = new D_UserMailEditViewModel(para, "D_Manage", identifier);
            return await EditShow(viewmodel, identifier);
        }
        public static async Task<BaseDialogResult> EditShow(D_UserMailEditViewModel viewmodel, string identifier)
        {           
            var dialog = new D_UserMailEdit(viewmodel);
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

        protected override async void Edit(D_UserMailDTO para = null)
        {
            var viewmodel = new D_UserMailEditViewModel(para, "D_Manage", Identifier);
            var res = await EditShow(viewmodel, Identifier);
            if (res == BaseDialogResult.OK || res == BaseDialogResult.Other1)
            {
                try
                {
                    ShowWait();
                    if (res == BaseDialogResult.Other1)
                    {
                        viewmodel.Data.IsDraft = true;
                    }
                    else
                    {
                        viewmodel.Data.IsDraft = false;
                    }

                    var result = await _dataProvider.GetData<AjaxResult>($"/D_Manage/D_UserMail/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.IsOK)
                    {
                        throw new Exception(result.ErrorMessage);
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
            else if (para != null)
            {
                para.IsReaded = true;
            }
        }

        public void EditById(object[] id)
        {
            Edit(new D_UserMailDTO() { Id = id[0] as string });
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
