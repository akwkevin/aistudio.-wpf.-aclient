using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.ProtobufApi.Models;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.BasePage.Protobuf.ViewModels
{
    public class ProtobufWindowViewModel<T> : BaseWindowViewModel<T> where T : class, IIsChecked
    {
        public ProtobufWindowViewModel(string area, Type type, Type editType, string getDataList = "GetDataList") : base(area, type, editType, getDataList)
        {
        }

        protected override void InitDataProvider()
        {
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>("Protobuf");
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                PageInput_Protobuf data = new PageInput_Protobuf()
                {
                    PageIndex = Pagination.PageIndex,
                    PageRows = Pagination.PageRows,
                    SortField = Pagination.SortField,
                    SortType = Pagination.SortType,
                    Search = new Search_Protobuf
                    {
                        keyword = KeyWord,
                        condition = ConditionItem?.Tag.ToString(),
                    },
                    SearchKeyValues = SearchKeyValues.ToDictionary(p => p.Key, p => p.Value.ToString()),
                };

                var result = await _dataProvider.GetData<List<T>>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/{GetDataList}", data);
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<T>(result.Data);
                    if (Data.Any())
                    {
                        SelectedItem = Data.FirstOrDefault();
                    }
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

        protected override async Task SaveData(T para)
        {
            try
            {
                ShowWait();
                var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/SaveData", para);
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

        protected override async Task Delete(List<string> ids)
        {
            var sure = await MessageBoxDialog.Warning("确认删除吗?", "提示", Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/DeleteData", new Delete_Protobuf() { ids = ids });
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
        }
    }
}
