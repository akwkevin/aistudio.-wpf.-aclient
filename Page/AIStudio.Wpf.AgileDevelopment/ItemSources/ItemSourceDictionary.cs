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
        public static readonly string[] ReadOnlySource = new string[] { "Id", "CreateTime", "ModifyTime", "CreatorName", "ModifyName" };
        public static readonly string[] IgnoreSource = new string[] { "IsChecked", "Deleted", "CreatorId", "ModifyId", };

        public static Dictionary<string, ObservableCollection<ISelectOption>> Items = new Dictionary<string, ObservableCollection<ISelectOption>>();
        public static Dictionary<string, DictionaryTreeModel> Dictionarys = new Dictionary<string, DictionaryTreeModel>();
        public static IUserData _userData { get { return ContainerLocator.Current.Resolve<IUserData>(); } }

        static ItemSourceDictionary()
        {
            Items = _userData.Items;
            Dictionarys = _userData.Dictionarys;
        }
    }
}
