using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.D_Manage.Views;
using AIStudio.Wpf.EFCore.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Util.Controls;
using AIStudio.Core;

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

        public new void Initialize()
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

                var data = new
                {
                    PageIndex = Pagination.PageIndex,
                    PageRows = Pagination.PageRows,
                    SortField = Pagination.SortField,
                    SortType = Pagination.SortType,
                    Search = new
                    {
                        keyword = KeyWord,
                        condition = ConditionItem?.Tag,
                        userId = this.IndexType == 1 ? _operator.Property?.Id : "",
                        creatorId = this.IndexType == 2 || this.IndexType == 3 ? _operator.Property?.Id : "",
                        draft = this.IndexType == 3 ? true : false,
                    }                    
                };

                var result = await _dataProvider.GetData<List<D_UserMailDTO>>($"/D_Manage/D_UserMail/GetDataList", JsonConvert.SerializeObject(data));
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
