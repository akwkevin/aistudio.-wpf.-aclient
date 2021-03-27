using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IBase_UserLogBusiness
    {
        Task<PageResult<Base_UserLog>> GetLogListAsync(PageInput<UserLogsInputDTO> input);
        Task<List<SelectOption>> GetLogTypeListAsync();
        Task WriteUserLog(UserLogType userLogType, string msg);
    }

    public class UserLogsInputDTO
    {
        public string logContent { get; set; }
        public string logType { get; set; }
        public string opUserName { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
    }
}