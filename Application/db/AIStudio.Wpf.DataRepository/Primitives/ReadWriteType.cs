using System;

namespace AIStudio.Wpf.DataRepository
{
    /// <summary>
    /// 读写模式
    /// </summary>
    [Flags]
    public enum ReadWriteType
    {
        /// <summary>
        /// 只读
        /// </summary>
        Read = 1,

        /// <summary>
        /// 只写
        /// </summary>
        Write = 2
    }
}
