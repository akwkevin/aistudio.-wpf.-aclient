using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Core.Models
{
    public class WebResponse<T>
    {
        /// <summary>
        /// 请求是否OK
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 错误类型
        /// </summary>
        public int ErrorType { get; set; }

        /// <summary>
        /// IsOK = false时错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        public int Total { get; set; }

        /// <summary>
        /// 仅Query类返回
        /// </summary>
        public T ResponseItem { get; set; }

        public static WebResponse<T> Success(T responseItem, int total)
        {
            return new WebResponse<T> { IsOK = true, ResponseItem = responseItem, Total = total };
        }

        public static WebResponse<T> Failed(int errorType, string errorMessage)
        {
            return new WebResponse<T> { IsOK = false, ErrorType = errorType, ErrorMessage = errorMessage };
        }
    }

    public class WebResponse
    {
        /// <summary>
        /// 请求是否OK
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 错误类型
        /// </summary>
        public int ErrorType { get; set; }

        /// <summary>
        /// IsOK = false时错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        public static WebResponse Success()
        {
            return new WebResponse { IsOK = true };
        }

        public static WebResponse Failed(int errorType, string message)
        {
            return new WebResponse { IsOK = false, ErrorType = errorType, ErrorMessage = message };
        }
    }
}
