using System;

namespace AIStudio.Wpf.BasePage.Events
{
    /// <summary>
    /// 快捷键事件的发布和订阅的类
    /// </summary>
    public class KeyExcuteEvent : Prism.Events.PubSubEvent<Tuple<string,string>>
    {
    }
}
