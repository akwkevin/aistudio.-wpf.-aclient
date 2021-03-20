using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.Business
{
    /// <summary>
    /// 系统日志类型
    /// </summary>
    public enum LogType
    {
        系统跟踪,
        系统异常,
        系统用户管理,
        系统角色管理,
        接口密钥管理,
        部门管理,
        系统任务,  //aistudio
        系统任务执行,  //aistudio
        工作流程,  //aistudio
        WebSocket,  //aistudio
    }
}
