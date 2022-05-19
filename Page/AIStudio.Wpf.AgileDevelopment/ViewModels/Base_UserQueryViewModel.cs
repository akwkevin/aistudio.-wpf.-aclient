using AIStudio.Wpf.AgileDevelopment.Commons;
using AIStudio.Wpf.AgileDevelopment.Models;
using AIStudio.Wpf.AgileDevelopment.Views;

namespace AIStudio.Wpf.AgileDevelopment.ViewModels
{
    class Base_UserQueryViewModel: CommonQueryViewModel<Base_UserDTO, Base_UserDTO_Query>
    {
        public Base_UserQueryViewModel() : base("Base_Manage", typeof(Base_UserQueryEditViewModel))
        {

        }

        protected override void GetData(bool iswaiting = false)
        {
            #region 后台没有支持按字段进行筛选的查询,这里是针对这一个数据做的，并不通用
            var dic = QueryConditionItem.ListToDictionary(QueryConditionItems);
            if (dic.ContainsKey("UserName"))
            {
                KeyWord = dic["UserName"]?.ToString();
            }
            else
            {
                KeyWord = null;
            }
            #endregion

            base.GetData(iswaiting);
        }
    }
}
