using AIStudio.Core;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.AgileDevelopment.ItemSources
{
    public static class ItemSourceDictionary
    {
        public static Dictionary<string, ObservableCollection<ISelectOption>> Items = new Dictionary<string, ObservableCollection<ISelectOption>>();
        private static IUserData _userData;

        static ItemSourceDictionary()
        {
            //Init();
        }

        public static async void Init()
        {
            _userData = ContainerLocator.Current.Resolve<IUserData>();
            Items.Add("Sex", new ObservableCollection<ISelectOption>()
            {
                new SelectOption() { Value = "0", Text = "女" }, new SelectOption() { Value = "1", Text = "男" }
            });
            Items.Add("User", await _userData.GetAllUser());
            Items.Add("Role", await _userData.GetAllRole());
            Items.Add("Department", await _userData.GetAllDepartment());
            Items.Add("TreeDepartment", await _userData.GetAllTreeDepartment());
        }
    }
}
