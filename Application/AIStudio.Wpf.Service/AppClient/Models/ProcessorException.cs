using AIStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    public class ProcessorException : ApplicationException
    {
        private string error;
        private ResponseCode code;
        private Exception innerException;
        //无参数构造函数
        public ProcessorException():base()
        {
            
        }
        //带一个字符串参数的构造函数，作用：当程序员用Exception类获取异常信息而非 MyException时把自定义异常信息传递过去
        public ProcessorException(string msg) : base(msg)
        {
            this.error = msg;
        }

        public ProcessorException(ResponseCode code, string msg) : base(msg)
        {
            this.error = msg;
            this.code = code;
        }

        //带有一个字符串参数和一个内部异常信息参数的构造函数
        public ProcessorException(string msg, Exception innerException) : base(msg)
        {
            this.innerException = innerException;
            this.error = msg;
        }
        public string GetError()
        {
            return error;
        }

        public ResponseCode GetResponseCode()
        {
            return code;
        }
    }    
}
