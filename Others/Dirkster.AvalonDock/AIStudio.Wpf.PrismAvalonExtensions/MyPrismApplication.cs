using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;

namespace AIStudio.Wpf.PrismAvalonExtensions
{
    public abstract class MyPrismApplication : PrismApplication
    {
        protected override Window CreateShell()
        {
            throw new NotImplementedException();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
