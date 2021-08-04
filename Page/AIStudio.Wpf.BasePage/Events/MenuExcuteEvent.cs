using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.BasePage.Events
{
    /// <summary>
    /// 快捷键事件的发布和订阅的类
    /// </summary>
    public class MenuExcuteEvent : Prism.Events.PubSubEvent<Tuple<string, string>>
    {
    }
}
