using AIStudio.Core.Models;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Home.ViewModels;
using AutoMapper;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Home_Dev.MainViews
{
    public class MainDevViewModel : MainViewModel
    {
        public MainDevViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator aggregator, IOperator ioperator, IDataProvider dataProvider, IWSocketClient wSocketClient, IMapper mapper, IUserData userData) : base(container, regionManager, aggregator, ioperator, dataProvider, wSocketClient, mapper, userData)
        {
        }

        public async override Task InitData()
        {
            await base.InitData();

            var protobufProvider = ContainerLocator.Current.Resolve<IDataProvider>("Protobuf");
            protobufProvider.Url = _dataProvider.Url;
            protobufProvider.Header = _dataProvider.Header;
            protobufProvider.TimeOut = _dataProvider.TimeOut;

            var code = MenuItems.FirstOrDefault(p => p.Code == "Demo");
            if (code != null)
            {
                code.AddChildren(new AMenuItem() { Label = "protobuf-用户管理", Code = "/Protobuf_Test/Protobuf_UserQueryView/", Type = 1, Command = MenuExcuteCommand });
            }
        }
    }
}
