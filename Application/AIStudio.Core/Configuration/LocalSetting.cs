using AIStudio.Core.Models;
using System;
using System.Configuration;

namespace AIStudio.Core
{
    public class LocalSetting
    {
        public static string RootWindow = "RootWindow";
        public static string Title { get; set; } = Convert.ToString(ConfigurationManager.AppSettings["Title"]);
        public static string Language { get; set; } = ConfigurationManager.AppSettings["Language"];
        public static double FontSize { get; set; } = Convert.ToDouble(ConfigurationManager.AppSettings["FontSize"]);
        public static string FontFamily { get; set; } = Convert.ToString(ConfigurationManager.AppSettings["FontFamily"]);
        public static string Accent { get; set; } = ConfigurationManager.AppSettings["Accent"];
        public static string Theme { get; set; } = ConfigurationManager.AppSettings["Theme"];

        public static string NavigationLocation { get; set; } = ConfigurationManager.AppSettings["NavigationLocation"];

        public static string NavigationAccent { get; set; } = ConfigurationManager.AppSettings["NavigationAccent"];

        public static string TitleAccent { get; set; } = ConfigurationManager.AppSettings["TitleAccent"];

        public static string ToolBarLocation { get; set; } = ConfigurationManager.AppSettings["ToolBarLocation"];
    
        public static string StatusBarLocation { get; set; } = ConfigurationManager.AppSettings["StatusBarLocation"];

        public static string VerifyMode { get; set; } = Convert.ToString(ConfigurationManager.AppSettings["VerifyMode"]);
    
        public static string ScreenMode { get; set; } = ConfigurationManager.AppSettings["ScreenMode"];
        public static string Version { get; set; } = Convert.ToString(ConfigurationManager.AppSettings["Version"]);

        public static string ServerIP { get; set; } = ConfigurationManager.AppSettings["ServerIP"];

        public static bool ApiMode { get; set; } = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["ServerIP"]);

        public static string UpdateAddress { get; set; } = ConfigurationManager.AppSettings["UpdateAddress"];

        public static string ConString { get; } = ConfigurationManager.AppSettings["ConString"];

        public static string DatabaseType { get; } = ConfigurationManager.AppSettings["DatabaseType"] ?? "SqlServer";

        public static string DeleteMode { get; } = ConfigurationManager.AppSettings["DeleteMode"] ?? "Logic";

        public static Action<string> SettingChanged;

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
            
            if (SettingChanged != null)
            {
                SettingChanged(key);
            }
        }

        public static Configuration GetWriteSection(string key, ConfigurationSection section)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            ConfigurationSection lastsection = config.Sections[key];
            if (lastsection == null)
            {
                config.Sections.Add(key, section);
            }

            return config;
        }

        public static void SaveSection(Configuration config)
        {
            config.Save();
        }

        public static ConfigurationSection GetSection(string key)
        {
            try
            {
                return System.Configuration.ConfigurationManager.GetSection(key) as ConfigurationSection;
            }
            catch
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.Sections.Remove(key);
                config.Save();
                return null;
            }
        }
    }


}
