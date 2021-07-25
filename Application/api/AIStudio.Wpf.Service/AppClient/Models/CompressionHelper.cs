using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    /// <summary>
    /// 使用 SharpZipLib 进行压缩的辅助类，简化对字节数组和字符串进行压缩的操作。
    /// </summary>
    public class CompressionHelper
    {
        /// <summary>
        /// 从原始字节数组生成已压缩的字节数组。
        /// </summary>
        /// <param name="bytesToCompress">原始字节数组。</param>
        /// <returns>返回已压缩的字节数组</returns>
        public static byte[] Compress(byte[] bytesToCompress, CompressionType compressionProvider = CompressionType.GZip)
        {
            MemoryStream ms = new MemoryStream();
            Stream s = OutputStream(ms, compressionProvider);
            if (s is ZipOutputStream)
            {
                ZipOutputStream zs = s as ZipOutputStream;
                zs.SetLevel(6); // 0 - store only to 9 - means best compression
                //zs.Password = password;  // 密码
                ZipEntry entry = new ZipEntry("1");   // outname 内容名称
                entry.DateTime = DateTime.Now;
                entry.Size = bytesToCompress.Length;  // 内容大小
                zs.PutNextEntry(entry);//编写新的ZIP文件条目
            }
            s.Write(bytesToCompress, 0, bytesToCompress.Length);
            s.Close();
            return ms.ToArray();
        }
        /// <summary>
        /// 从原始字符串生成已压缩的字符串。
        /// </summary>
        /// <param name="stringToCompress">原始字符串。</param>
        /// <returns>返回已压缩的字符串。</returns>
        public static string Compress(string stringToCompress, CompressionType compressionProvider = CompressionType.GZip)
        {
            byte[] compressedData = CompressToByte(stringToCompress, compressionProvider);
            string strOut = Convert.ToBase64String(compressedData);
            return strOut;
        }
        /// <summary>
        /// 从原始字符串生成已压缩的字节数组。
        /// </summary>
        /// <param name="stringToCompress">原始字符串。</param>
        /// <returns>返回已压缩的字节数组。</returns>
        public static byte[] CompressToByte(string stringToCompress, CompressionType compressionProvider = CompressionType.GZip)
        {
            byte[] bytData = Encoding.Unicode.GetBytes(stringToCompress);
            return Compress(bytData, compressionProvider);
        }
        /// <summary>
        /// 从已压缩的字符串生成原始字符串。
        /// </summary>
        /// <param name="stringToDecompress">已压缩的字符串。</param>
        /// <returns>返回原始字符串。</returns>
        public static string DeCompress(string stringToDecompress, CompressionType compressionProvider = CompressionType.GZip)
        {
            string outString = string.Empty;
            if (stringToDecompress == null)
            {
                throw new ArgumentNullException("stringToDecompress", "You tried to use an empty string");
            }
            try
            {
                byte[] inArr = Convert.FromBase64String(stringToDecompress.Trim());
                outString = Encoding.Unicode.GetString(DeCompress(inArr, compressionProvider));
            }
            catch (NullReferenceException nEx)
            {
                return nEx.Message;
            }
            return outString;
        }
        /// <summary>
        /// 从已压缩的字节数组生成原始字节数组。
        /// </summary>
        /// <param name="bytesToDecompress">已压缩的字节数组。</param>
        /// <returns>返回原始字节数组。</returns>
        public static byte[] DeCompress(byte[] bytesToDecompress, CompressionType compressionProvider = CompressionType.GZip)
        {
            byte[] writeData = new byte[4096];
            Stream s2 = InputStream(new MemoryStream(bytesToDecompress), compressionProvider);
            if (s2 is ZipInputStream)
            {
                ZipInputStream zs2 = s2 as ZipInputStream;
                ZipEntry entry = zs2.GetNextEntry();
            }

            MemoryStream outStream = new MemoryStream();
            while (true)
            {
                int size = s2.Read(writeData, 0, writeData.Length);
                if (size > 0)
                {
                    outStream.Write(writeData, 0, size);
                }
                else
                {
                    break;
                }
            }
            s2.Close();
            byte[] outArr = outStream.ToArray();
            outStream.Close();
            return outArr;

        }

        /// <summary>
        /// 从给定的流生成压缩输出流。
        /// </summary>
        /// <param name="inputStream">原始流。</param>
        /// <returns>返回压缩输出流。</returns>
        private static Stream OutputStream(Stream inputStream, CompressionType compressionProvider)
        {
            switch (compressionProvider)
            {
                case CompressionType.BZip2:
                    return new BZip2OutputStream(inputStream);
                case CompressionType.GZip:
                    return new GZipOutputStream(inputStream);
                case CompressionType.Zip:
                    return new ZipOutputStream(inputStream);
                default:
                    return new GZipOutputStream(inputStream);
            }
        }
        /// <summary>
        /// 从给定的流生成压缩输入流。
        /// </summary>
        /// <param name="inputStream">原始流。</param>
        /// <returns>返回压缩输入流。</returns>
        private static Stream InputStream(Stream inputStream, CompressionType compressionProvider)
        {
            switch (compressionProvider)
            {
                case CompressionType.BZip2:
                    return new BZip2InputStream(inputStream);
                case CompressionType.GZip:
                    return new GZipInputStream(inputStream);
                case CompressionType.Zip:
                    return new ZipInputStream(inputStream);
                default:
                    return new GZipInputStream(inputStream);
            }
        }
    }
}
