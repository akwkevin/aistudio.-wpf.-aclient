﻿using Dataforge.PrismAvalonExtensions.Test.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace Dataforge.PrismAvalonExtensions.Test.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public DelegateCommand<string> NavigateCommand2 { get; private set; }
        public DelegateCommand<string> NavigateCommand3 { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            NavigateCommand2 = new DelegateCommand<string>(Navigate2);
            NavigateCommand3 = new DelegateCommand<string>(Navigate3);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }

        private void Navigate2(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion2", navigatePath);
        }

        private void Navigate3(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion3", navigatePath);
        }
    }
}
