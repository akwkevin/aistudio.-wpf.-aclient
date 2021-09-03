using AIStudio.Wpf.Business;
using AutoMapper;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Home.ViewModels
{
    class FullScreenViewModel: MainViewModel
    {
        public FullScreenViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator aggregator, IOperator ioperator, IDataProvider dataProvider, IWSocketClient wSocketClient, IMapper mapper)
            :base(container,regionManager, aggregator, ioperator, dataProvider, wSocketClient, mapper)
        {

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }

            RegionName = AIStudio.Core.RegionName.SingleContentRegion + "_" + Identifier;
        }

        public override void KeyExcute(string key)
        {
            if (key == "Escape")
            {
                key = "EscapeFullScreen";
            }
            base.KeyExcute(key);
        }
    }
}
