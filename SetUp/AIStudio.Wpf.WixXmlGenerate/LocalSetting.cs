using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.WixXmlGenerate
{
    public class LocalSetting
    {       
        public static string SourcePath { get; set; } = Convert.ToString(ConfigurationManager.AppSettings["SourcePath"]);
        public static string DestPath { get; set; } = ConfigurationManager.AppSettings["DestPath"];
        public static string Filter { get; set; } = ConfigurationManager.AppSettings["Filter"];
        
        public LocalSetting()
        {

        }

        /// <summary>
        /// 保存appSetting
        /// </summary>
        /// <param name="key">appSetting的KEY值</param>
        /// <param name="value">appSetting的Value值</param>
        public static void SetAppSetting(string key, object value)
        {

            //静态类的获取方法
            if (typeof(LocalSetting).GetProperty(key).GetValue(typeof(LocalSetting)) == value)
                return;

            // 创建配置文件对象
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
            {
                // 修改
                config.AppSettings.Settings[key].Value = value.ToString();
            }
            else
            {
                // 添加
                AppSettingsSection ass = (AppSettingsSection)config.GetSection("appSettings");
                ass.Settings.Add(key, value.ToString());
            }

            // 保存修改
            config.Save(ConfigurationSaveMode.Modified);

            // 强制重新载入配置文件的连接配置节
            ConfigurationManager.RefreshSection("appSettings");

            //静态类的设置方法
            typeof(LocalSetting).GetProperty(key).SetValue(typeof(LocalSetting), value);
        }

    }
}
