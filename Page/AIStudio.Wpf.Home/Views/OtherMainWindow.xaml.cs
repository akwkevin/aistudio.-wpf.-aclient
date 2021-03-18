using AIStudio.Wpf.BasePage.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.Home
{
    /// <summary>
    /// OtherMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OtherMainWindow : WindowBase
    {
        protected IRegionManager _regionManager { get => ContainerLocator.Current.Resolve<IRegionManager>(); }
        protected IEventAggregator _eventAggregator { get => ContainerLocator.Current.Resolve<IEventAggregator>(); }

        public static List<int> Numbers = null;
        public int _key;
        public OtherMainWindow()
        {
            InitializeComponent();

            RegionManager.SetRegionManager(this, _regionManager);//这个很重要，与View进行绑定，不然RequestNavigate不好使

            if (Numbers == null)
            {
                Numbers = new List<int>();
            }
            
            if (Numbers.Count == 0)
            {   
                _key = 1;
            }
            else
            {
                var number = Enumerable.Range(1, Numbers.Max()).Except(Numbers).FirstOrDefault();
                if (number > 0)
                {
                    _key = number;
                }
                else
                {
                    _key = Numbers.Max() + 1;
                }
            }

            Numbers.Add(_key);
            Identifier = $"Window{_key}";
            RegionName = AIStudio.Core.RegionName.MainContentRegion + "_" + Identifier;
            this.Closing += MainWindow_Closing;           
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBoxHelper.ShowSure("确定要关闭此窗口?", this);
            if (result != MessageBoxResult.OK)
            {
                e.Cancel = true;
                return;
            }

            Numbers.Remove(_key);
            _regionManager.Regions.Remove(RegionName);
            _regionManager.Regions.Remove(AIStudio.Core.RegionName.TabContentRegion + "_" + Identifier);
        }


        public static readonly DependencyProperty RegionNameProperty = DependencyProperty.Register(
          "RegionName", typeof(string), typeof(OtherMainWindow), new PropertyMetadata(""));

        public string RegionName
        {
            get { return (string)GetValue(RegionNameProperty); }
            set { SetValue(RegionNameProperty, value); }
        }

        private ICommand keyCommand;
        public ICommand KeyCommand
        {
            get
            {
                return this.keyCommand ?? (this.keyCommand = new DelegateCommand<string>(para => this.KeyExcute(para)));
            }
        }

        private void KeyExcute(string para)
        {
            _eventAggregator.GetEvent<KeyExcuteEvent>().Publish(new Tuple<string, string>(Identifier.ToString(), para));
        }
    }
}
