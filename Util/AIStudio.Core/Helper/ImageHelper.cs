using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AIStudio.Core.Helpers
{
    public class ImageHelper
    {
        ///// <summary>
        ///// 判断文件是否为图片
        ///// </summary>
        ///// <param name="path">文件的完整路径</param>
        ///// <returns>返回结果</returns>
        //public static bool IsImage(string path)
        //{
        //    try
        //    {
        //        System.Drawing.Image img = System.Drawing.Image.FromFile(path);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 根据文件头判断上传的文件类型
        ///// </summary>
        ///// <param name="filePath">filePath是文件的完整路径 </param>
        ///// <returns>返回true或false</returns>
        //public static bool IsPicture(string filePath)
        //{
        //    try
        //    {
        //        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //        BinaryReader reader = new BinaryReader(fs);
        //        string fileClass;
        //        byte buffer;
        //        buffer = reader.ReadByte();
        //        fileClass = buffer.ToString();
        //        buffer = reader.ReadByte();
        //        fileClass += buffer.ToString();
        //        reader.Close();
        //        fs.Close();
        //        if (fileClass == "255216" || fileClass == "7173" || fileClass == "13780" || fileClass == "6677")
        //        //255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar 
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        #region 识别path是否是网络路径
        /// <summary>
        /// 识别path是否是网络路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool UrlDiscern(string path)
        {
            if (Regex.IsMatch(path, @"(http|ftp|https)://"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
