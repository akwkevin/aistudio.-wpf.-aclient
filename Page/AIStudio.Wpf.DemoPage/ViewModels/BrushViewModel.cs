using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ControlzEx.Theming;
using Prism.Commands;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class BrushViewModel : DockWindowViewModel
    {
        public IEnumerable<string> BrushResources { get; private set; }

        public List<AccentColorMenuData> AccentColors { get; set; }

        public List<AppThemeMenuData> AppThemes { get; set; }

        public ICommand ChangeSyncModeCommand { get; } = new DelegateCommand<object>(x =>
        {
            ThemeManager.Current.ThemeSyncMode = (ThemeSyncMode)x;
            ThemeManager.Current.SyncTheme();
        });

        public ICommand SyncThemeNowCommand { get; } = new DelegateCommand(() => ThemeManager.Current.SyncTheme());

        public BrushViewModel()
        {
            // create accent color menu items for the demo
            this.AccentColors = ThemeManager.Current.Themes
                                            .GroupBy(x => x.ColorScheme)
                                            .OrderBy(a => a.Key)
                                            .Select(a => new AccentColorMenuData { Name = a.Key, ColorBrush = a.First().ShowcaseBrush })
                                            .ToList();

            // create metro theme color menu items for the demo
            this.AppThemes = ThemeManager.Current.Themes
                                         .GroupBy(x => x.BaseColorScheme)
                                         .Select(x => x.First())
                                         .Select(a => new AppThemeMenuData() { Name = a.BaseColorScheme, BorderColorBrush = a.Resources["MahApps.Brushes.ThemeForeground"] as Brush, ColorBrush = a.Resources["MahApps.Brushes.ThemeBackground"] as Brush })
                                         .ToList();

            BrushResources = FindBrushResources();
        }

        private void OK()
        {

        }

        private IEnumerable<string> FindBrushResources()
        {
            if (Application.Current.MainWindow != null)
            {
                var theme = ThemeManager.Current.DetectTheme(Application.Current.MainWindow);

                var resources = theme.LibraryThemes.First(x => x.Origin == "MahApps.Metro").Resources.MergedDictionaries.First();

                var brushResources = resources.Keys
                                              .Cast<object>()
                                              .Where(key => resources[key] is SolidColorBrush)
                                              .Select(key => key.ToString())
                                              .OrderBy(s => s)
                                              .ToList();

                return brushResources;
            }

            return Enumerable.Empty<string>();
        }


    }

    public class AccentColorMenuData
    {
        public string Name { get; set; }

        public Brush BorderColorBrush { get; set; }

        public Brush ColorBrush { get; set; }

        public AccentColorMenuData()
        {
            this.ChangeAccentCommand = new DelegateCommand<object>(obj => this.DoChangeTheme(obj));
        }

        public ICommand ChangeAccentCommand { get; }

        protected virtual void DoChangeTheme(object sender)
        {
            ThemeManager.Current.ChangeThemeColorScheme(Application.Current, this.Name);
        }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme(object sender)
        {
            ThemeManager.Current.ChangeThemeBaseColor(Application.Current, this.Name);
        }
    }
}
