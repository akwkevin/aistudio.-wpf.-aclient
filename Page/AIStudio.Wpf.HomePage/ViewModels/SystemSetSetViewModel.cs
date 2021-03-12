using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.HomePage.Models;
using ControlzEx.Theming;
using MahApps.Metro;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Util.Controls;

namespace AIStudio.Wpf.HomePage.ViewModels
{
    public class SystemSetViewModel : BindableBase
    {
        private static ILogger _logger { get => ContainerLocator.Current.Resolve<ILogger>(); }
     
        public SystemSetViewModel()
        {
            // create accent color menu items for the demo
            this.AccentColors = ThemeManager.Current.Themes
                                           .GroupBy(x => x.ColorScheme)
                                           .OrderBy(a => a.Key)
                                           .Select(a => new AccentColorMenuData { Name = a.Key, ColorBrush = a.First().ShowcaseBrush })
                                           .ToList();

            this.SelectedAccentColor = this.AccentColors.FirstOrDefault(p => p.Name == LocalSetting.Accent);

            // create metro theme color menu items for the demo
            this.AppThemes = ThemeManager.Current.Themes
                                .GroupBy(x => x.BaseColorScheme)
                                .Select(x => x.First())
                                .Select(a => new AppThemeMenuData() { Name = a.BaseColorScheme, BorderColorBrush = a.Resources["MahApps.Brushes.ThemeForeground"] as Brush, ColorBrush = a.Resources["MahApps.Brushes.ThemeBackground"] as Brush })
                                .ToList();
            this.SelectedAppTheme = this.AppThemes.FirstOrDefault(p => p.Name == LocalSetting.Theme);

            this.AppNavigations = new List<AppNavigationMenuData>()
            {
                new AppNavigationMenuData() { Name = "导航栏暗色", NavigationAccent = "Dark" },
                new AppNavigationMenuData() { Name = "导航栏淡色", NavigationAccent = "Light" }
            };
            this.SelectedAppNavigation = this.AppNavigations.FirstOrDefault(p => p.NavigationAccent == LocalSetting.NavigationAccent);

            this.SelectedNavigationLocation = (int)(NavigationLocation)System.Enum.Parse(typeof(NavigationLocation), LocalSetting.NavigationLocation);

            this.SelectedTitleAccent = (int)(TitleAccent)System.Enum.Parse(typeof(TitleAccent), LocalSetting.TitleAccent);

            this.SelectedToolBarLocation = (int)(ToolBarLocation)System.Enum.Parse(typeof(ToolBarLocation), LocalSetting.ToolBarLocation);

            this.SelectedStatusBarLocation = (int)(StatusBarLocation)System.Enum.Parse(typeof(StatusBarLocation), LocalSetting.StatusBarLocation);

            this.SystemFontFamilies = new List<FontFamily>();
            foreach (FontFamily _f in Fonts.SystemFontFamilies)
            {
                LanguageSpecificStringDictionary _fontDic = _f.FamilyNames;
                if (_fontDic.ContainsKey(XmlLanguage.GetLanguage("zh-cn")))
                {
                    string _fontName = null;
                    if (_fontDic.TryGetValue(XmlLanguage.GetLanguage("zh-cn"), out _fontName))
                    {
                        this.SystemFontFamilies.Add(new FontFamily(_fontName));
                    }
                }
                //else
                //{
                //    string _fontName = null;
                //    if (_fontDic.TryGetValue(XmlLanguage.GetLanguage("en-us"), out _fontName))
                //    {
                //        SystemFontFamilies.Add(new FontFamily(_fontName));
                //    }
                //}
            }

            this._fontFamily = this.SystemFontFamilies.FirstOrDefault(p => p.Source == LocalSetting.FontFamily);
            this._fontSize = LocalSetting.FontSize;
            this._isChinese = LocalSetting.Language == "中文";
        }

        #region 字段和属性
        public List<AccentColorMenuData> AccentColors { get; set; }

        private AccentColorMenuData _selectedAccentColor;
        public AccentColorMenuData SelectedAccentColor
        {
            get { return _selectedAccentColor; }
            set
            {
                SetProperty(ref _selectedAccentColor, value);
            }
        }
        public List<AppThemeMenuData> AppThemes { get; set; }

        private AppThemeMenuData _selectedAppTheme;
        public AppThemeMenuData SelectedAppTheme
        {
            get { return _selectedAppTheme; }
            set
            {
                SetProperty(ref _selectedAppTheme, value);
            }
        }
        public List<AppNavigationMenuData> AppNavigations { get; set; }

        private AppThemeMenuData _selectedAppNavigation;
        public AppThemeMenuData SelectedAppNavigation
        {
            get { return _selectedAppNavigation; }
            set
            {
                SetProperty(ref _selectedAppNavigation, value);
            }
        }

        private int _selectedNavigationLocation;
        public int SelectedNavigationLocation
        {
            get { return _selectedNavigationLocation; }
            set
            {
                SetProperty(ref _selectedNavigationLocation, value);
            }
        }

        private int _selectedTitleAccent;
        public int SelectedTitleAccent
        {
            get { return _selectedTitleAccent; }
            set
            {
                SetProperty(ref _selectedTitleAccent, value);
            }
        }

        private int _selectedToolBarLocation;
        public int SelectedToolBarLocation
        {
            get { return _selectedToolBarLocation; }
            set
            {
                SetProperty(ref _selectedToolBarLocation, value);
            }
        }

        private int _selectedStatusBarLocation;
        public int SelectedStatusBarLocation
        {
            get { return _selectedStatusBarLocation; }
            set
            {
                SetProperty(ref _selectedStatusBarLocation, value);
            }
        }

        private double _fontSize;
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (SetProperty(ref _fontSize, value))
                {
                    FontSizeChange(_fontSize);
                }
            }
        }

        private bool _isChinese;

        public bool IsChinese
        {
            get { return _isChinese; }
            set
            {
                if (SetProperty(ref _isChinese, value))
                {
                    LanguageChange(_isChinese);
                }
            }
        }

        public List<FontFamily> SystemFontFamilies { get; set; }

        private FontFamily _fontFamily;
        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set
            {
                if (SetProperty(ref _fontFamily, value))
                {
                    FontFamilyChange(_fontFamily);
                }
            }
        }
        #endregion

        private void LanguageChange(bool chinese)
        {
            string language = chinese ? "中文" : "英文";
            LocalSetting.SetAppSetting("Language", language);
            InitLanguage();
        }

        private void FontSizeChange(double size)
        {
            LocalSetting.SetAppSetting("FontSize", size);
            InitFontSize();
        }

        private void FontFamilyChange(FontFamily fontFamily)
        {
            LocalSetting.SetAppSetting("FontFamily", fontFamily.Source);
            InitFontFamily();
        }

        private ICommand navigationLocationCommand;
        public ICommand NavigationLocationCommand
        {
            get
            {
                return this.navigationLocationCommand ?? (this.navigationLocationCommand = new DelegateCommand<object>(para => this.NavigationLocation(para)));
            }
        }


        private ICommand _titleAccentCommand;
        public ICommand TitleAccentCommand
        {
            get
            {
                return this._titleAccentCommand ?? (this._titleAccentCommand = new DelegateCommand<object>(para => this.TitleAccent(para)));
            }
        }

        public ICommand _toolBarLocationCommand;
        public ICommand ToolBarLocationCommand
        {
            get
            {
                return this._toolBarLocationCommand ?? (this._toolBarLocationCommand = new DelegateCommand<object>(para => this.ToolBarLocation(para)));
            }
        }

        public ICommand _statusBarLocationCommand;
        public ICommand StatusBarLocationCommand
        {
            get
            {
                return this._statusBarLocationCommand ?? (this._statusBarLocationCommand = new DelegateCommand<object>(para => this.StatusBarLocation(para)));
            }
        }

        private ICommand _changeThemeCommand;

        public ICommand ChangeThemeCommand
        {
            get { return this._changeThemeCommand ?? (_changeThemeCommand = new DelegateCommand<object>(x => this.DoChangeTheme(x))); }
        }

        private ICommand _changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this._changeAccentCommand ?? (_changeAccentCommand = new DelegateCommand<object>(x => this.DoChangeAccent(x))); }
        }

        private ICommand _changeNavigationAccentCommand;

        public ICommand ChangeNavigationAccentCommand
        {
            get { return this._changeNavigationAccentCommand ?? (_changeNavigationAccentCommand = new DelegateCommand<object>(x => this.DoChangeNavigationAccent(x))); }
        }

        private void DoChangeTheme(object para)
        {
            AppThemeMenuData data = para as AppThemeMenuData;
            if (data != null)
            {
                ThemeManager.Current.ChangeThemeBaseColor(Application.Current, data.Name);
                LocalSetting.SetAppSetting("Theme", data.Name);
               
                if (ThemeChangedHelper.IsThemeChanged !=null)
                    ThemeChangedHelper.IsThemeChanged();
            }
        }
        private void DoChangeAccent(object para)
        {
            AccentColorMenuData data = para as AccentColorMenuData;
            if (data != null)
            {
                ThemeManager.Current.ChangeThemeColorScheme(Application.Current, data.Name);
                LocalSetting.SetAppSetting("Accent", data.Name);

            
                if (ThemeChangedHelper.IsThemeChanged != null)
                    ThemeChangedHelper.IsThemeChanged();
            }
        }

        private void DoChangeAddition(string oldname, string newname)
        {
            try
            {
                string requestedStyle = "/AIStudio.Resource;component/Colors/Themes/" + oldname + "Addition.xaml";
                ResourceDictionary resourceAdditionDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source.OriginalString.Equals(@requestedStyle));
                Application.Current.Resources.MergedDictionaries.Remove(resourceAdditionDictionary);
                requestedStyle = "/AIStudio.Resource;component/Colors/Themes/" + newname + "Addition.xaml";
                resourceAdditionDictionary = new ResourceDictionary();
                resourceAdditionDictionary.Source = new Uri(@requestedStyle, UriKind.RelativeOrAbsolute);
                Application.Current.Resources.MergedDictionaries.Add(resourceAdditionDictionary);
                resourceAdditionDictionary.Add("TitleBackgroundBrush", resourceAdditionDictionary[LocalSetting.TitleAccent == "Accent" ? "TitleBackgroundBrush2" : "TitleBackgroundBrush1"]);
                resourceAdditionDictionary.Add("TitleForegroundBrush", resourceAdditionDictionary[LocalSetting.TitleAccent == "Accent" ? "TitleForegroundBrush2" : "TitleForegroundBrush1"]);
            }
            catch { }
        }

        private void DoChangeNavigationAccent(object sender)
        {
            AppNavigationMenuData navigationAccent = sender as AppNavigationMenuData;
            if (navigationAccent != null)
            {
                LocalSetting.SetAppSetting("NavigationAccent", navigationAccent.NavigationAccent);
            }
        }

        private void NavigationLocation(object para)
        {
            LocalSetting.SetAppSetting("NavigationLocation", ((NavigationLocation)para).ToString());
        }

        private void TitleAccent(object para)
        {
            try
            {
                LocalSetting.SetAppSetting("TitleAccent", ((TitleAccent)para).ToString());
                InitThemeAddition();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void ToolBarLocation(object para)
        {
            LocalSetting.SetAppSetting("ToolBarLocation", ((ToolBarLocation)para).ToString());
        }

        private void StatusBarLocation(object para)
        {
            LocalSetting.SetAppSetting("StatusBarLocation", ((StatusBarLocation)para).ToString());
        }

        public static void InitSetting()
        {
            InitFontSize();
            InitFontFamily();
            InitTheme();
            InitLanguage();
        }

        public static void InitFontSize()
        {
            #region 加载字体大小
            List<ResourceDictionary> dictionaryList = Application.Current.Resources.MergedDictionaries.ToList();

            string requestedCulture = @"/AIStudio.Wpf.HomePage;component/Themes/FontSizeDictionary.xaml";
            ResourceDictionary resourceDictionary = dictionaryList.Where(d => d.Source != null && d.Source.OriginalString.Equals(requestedCulture)).FirstOrDefault();

            resourceDictionary.Clear();
            resourceDictionary.Add("MahApps.Font.Size.Header", LocalSetting.FontSize + 2);
            resourceDictionary.Add("MahApps.Font.Size.SubHeader", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Window.Title", LocalSetting.FontSize + 2);
            resourceDictionary.Add("MahApps.Font.Size.Default", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Content", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Button.Flat", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.TabItem", LocalSetting.FontSize + 2);
            resourceDictionary.Add("MahApps.Font.Size.Button", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.FloatingWatermark", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Button.ClearText", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Tooltip", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Menu", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.ContextMenu", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.StatusBar", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Dialog.Title", LocalSetting.FontSize + 2);
            resourceDictionary.Add("MahApps.Font.Size.Dialog.Message", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Dialog.Button", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.Flyout.Header", LocalSetting.FontSize + 2);
            resourceDictionary.Add("MahApps.Font.Size.ToggleSwitch", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.ToggleSwitch.Header", LocalSetting.FontSize);
            resourceDictionary.Add("MahApps.Font.Size.ColorPicker.TabItemHeader", LocalSetting.FontSize);

            Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            #endregion
        }



        public static void InitFontFamily()
        {
            #region 加载字体
            List<ResourceDictionary> dictionaryList = Application.Current.Resources.MergedDictionaries.ToList();

            FontFamily fontFamily = null;

            foreach (FontFamily fontfamily in Fonts.SystemFontFamilies)
            {
                LanguageSpecificStringDictionary fontdics = fontfamily.FamilyNames;                //判断该字体是不是中文字体       
                if (fontdics.ContainsKey(XmlLanguage.GetLanguage("zh-cn")))
                {
                    string fontfamilyname = null;
                    if (fontdics.TryGetValue(XmlLanguage.GetLanguage("zh-cn"), out fontfamilyname))
                    {
                        if (fontfamilyname.Contains(LocalSetting.FontFamily))
                        { fontFamily = fontfamily; break; }
                    }
                }                //英文字体     
                else
                {
                    string fontfamilyname = null;
                    if (fontdics.TryGetValue(XmlLanguage.GetLanguage("en-us"), out fontfamilyname))
                    {
                        if (fontfamilyname.Contains(LocalSetting.FontFamily))
                        { fontFamily = fontfamily; break; }
                    }
                }
            }

            if (fontFamily == null)
                return;

            string requestedCulture = @"/AIStudio.Wpf.HomePage;component/Themes/FontFamilyDictionary.xaml";
            ResourceDictionary resourceDictionary = dictionaryList.Where(d => d.Source != null && d.Source.OriginalString.Equals(requestedCulture)).FirstOrDefault();

            resourceDictionary.Clear();
            resourceDictionary.Add("MahApps.Fonts.Family.SymbolTheme", fontFamily);
            resourceDictionary.Add("MahApps.Fonts.Family.Button", fontFamily);
            resourceDictionary.Add("MahApps.Fonts.Family.Header", fontFamily);
            resourceDictionary.Add("MahApps.Fonts.Family.Window.Title", fontFamily);
            resourceDictionary.Add("MahApps.Fonts.Family.Control", fontFamily);
            resourceDictionary.Add("MahApps.Fonts.Family.ToggleSwitch", fontFamily);
            resourceDictionary.Add("MahApps.Fonts.Family.ToggleSwitch.Header", fontFamily);

            Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            #endregion
        }

        private static void InitThemeAddition()
        {
            Application.Current.Resources.Remove("TitleBackgroundBrush");
            Application.Current.Resources.Remove("TitleForegroundBrush");
            Application.Current.Resources.Add("TitleBackgroundBrush", LocalSetting.TitleAccent == "Accent" ? Application.Current.FindResource("MahApps.Brushes.AccentBase") :  Application.Current.FindResource("MahApps.Brushes.Accent"));
            Application.Current.Resources.Add("TitleForegroundBrush", LocalSetting.TitleAccent == "Accent" ? Application.Current.FindResource("MahApps.Brushes.Accent") : Application.Current.FindResource("MahApps.Brushes.ThemeForeground"));
        }

        public static void InitTheme()
        {
            #region 加载主题
            try
            {
                List<ResourceDictionary> dictionaryList = Application.Current.Resources.MergedDictionaries.ToList();

                var theme = ThemeManager.Current.DetectTheme(Application.Current);
                if (theme.BaseColorScheme == LocalSetting.Theme && theme.ColorScheme == LocalSetting.Accent)
                {
                    return;
                }

                ThemeManager.Current.ChangeThemeBaseColor(Application.Current, LocalSetting.Theme);
                ThemeManager.Current.ChangeThemeColorScheme(Application.Current, LocalSetting.Accent);

                //添加额外的信息
                InitThemeAddition();

                //在加载一些颜色
                string requestedCulture = "/AIStudio.Resource;component/Brushs/Brushes.xaml";
                ResourceDictionary resourceDictionary = Application.Current.Resources.MergedDictionaries.Where(d => d.Source != null && d.Source.OriginalString.Equals(requestedCulture)).FirstOrDefault();
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            #endregion
        }

        public static void InitLanguage()
        {
            List<ResourceDictionary> dictionaryList = Application.Current.Resources.MergedDictionaries.ToList();
            string chineseCulture = @"/AIStudio.Resource;component/Themes/zh-cn.xaml";
            string englishCulture = @"/AIStudio.Resource;component/Themes/en-us.xaml";
            string requestedCulture = LocalSetting.Language == "中文" ? chineseCulture : englishCulture;
            ResourceDictionary resourceDictionary = dictionaryList.Where(d => d.Source != null && d.Source.OriginalString.Equals(requestedCulture)).FirstOrDefault();
            Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
