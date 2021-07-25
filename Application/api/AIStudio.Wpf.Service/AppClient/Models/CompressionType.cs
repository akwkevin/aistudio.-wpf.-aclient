using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    ///// <summary>
    ///// 压缩方式。
    ///// </summary>
    public enum CompressionType
    {
        None,
        /// <summary>
        /// GZip 压缩格式
        /// </summary>
        GZip,
        /// <summary>
        /// BZip2 压缩格式
        /// </summary>
        BZip2,
        /// <summary>
        /// Zip 压缩格式
        /// </summary>
        Zip
    }
}
