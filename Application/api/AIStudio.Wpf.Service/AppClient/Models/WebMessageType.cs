using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum WebMessageType : short
    {
        QueryRequest = 1001,
        AddRequest,
        ModifyRequest,
        DeleteRequest,
        ComplexOperationRequest,       
        ComplexQueryRequest,    
        /// <summary>
        /// 直接使用SQL语句查询数据，这个接口不规范，只有在使用常规接口无法实现功能的情况下才使用，请勿滥用
        /// </summary>
        QueryWithCustomSQLRequest = 1100,     
    }
}
