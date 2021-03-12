using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AIStudio.Wpf.LocalConfiguration
{
    public interface IUserConfig
    {
        void Initialize();

        ObservableCollection<LoginInfo> LoginInfo { get; set; }
        void AddLoginInfo(LoginInfo info);

        void WriteConfig(string file, object info);
        void WriteConfig(object obj, object info);
        T ReadConfig<T>(string file) where T : new();
        T ReadConfig<T>(object obj) where T : new();
    }
}
