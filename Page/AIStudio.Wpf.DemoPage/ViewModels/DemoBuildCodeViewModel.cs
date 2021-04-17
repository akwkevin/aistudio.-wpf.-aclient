using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Util.Controls;
using Util.Controls.Helper;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class DemoBuildCodeViewModel : DockWindowViewModel
    {        
        private string demoName;
        public string DemoName
        {
            get { return demoName; }
            set
            {
                if (value != demoName)
                {
                    demoName = value;
                    RaisePropertyChanged("DemoName");
                }
            }
        }

        private ICommand generateCommand;
        public ICommand GenerateCommand
        {
            get
            {
                return this.generateCommand ?? (this.generateCommand = new DelegateCommand(() => this.Generate()));
            }
        }


        private string directory;
        private string tmpFileText;
        private string savePath;

        public DemoBuildCodeViewModel()
        {
            directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString()).ToString()).ToString()).ToString();
            GetTypes();
        }

        private ObservableCollection<Type> _types = new ObservableCollection<Type>();
        public ObservableCollection<Type> Types
        {
            get { return _types; }
            set
            {
                if (_types != value)
                {
                    _types = value;
                    //OnPropertyChanged(nameof(Title));
                    RaisePropertyChanged("Types");
                }
            }
        }

        private void Generate()
        {
            #region ViewModel
            tmpFileText = File.ReadAllText(Path.Combine(directory, "AIStudio.Wpf.DemoPage", "BuildCodeTemplate" , "demo_viewmodel.txt"));
 
            tmpFileText = tmpFileText.Replace("%demoName%", DemoName);

            savePath = Path.Combine(
                           directory,
                           "AIStudio.Wpf.DemoPage",
                           "ViewModels",
                           $"{DemoName}ViewModel.cs");

            FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
            #endregion

            #region View
            tmpFileText = File.ReadAllText(Path.Combine(directory, "AIStudio.Wpf.DemoPage", "BuildCodeTemplate", "demo_view.txt"));

            tmpFileText = tmpFileText.Replace("%demoName%", DemoName);

            savePath = Path.Combine(
                           directory,
                           "AIStudio.Wpf.DemoPage",
                           "Views",
                           $"{DemoName}View.xaml");

            FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
            #endregion

            #region View.cs
            tmpFileText = File.ReadAllText(Path.Combine(directory, "AIStudio.Wpf.DemoPage", "BuildCodeTemplate", "demo_viewcs.txt"));

            tmpFileText = tmpFileText.Replace("%demoName%", DemoName);

            savePath = Path.Combine(
                           directory,
                           "AIStudio.Wpf.DemoPage",
                           "Views",
                           $"{DemoName}View.xaml.cs");

            FileHelper.WriteTxt(tmpFileText, savePath, Encoding.UTF8, FileMode.Create);
            #endregion

            MessageBoxHelper.ShowInfo("生成完成");
        }

        private void GetTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(DockWindowViewModel)))
                {
                    Types.Add(type);                    
                }
            }
        }
    }
}
