using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    public static class GZipUtil
    {
        public static string Zip(string value)
        {            //Transform string into byte[]         
            byte[] byteArray = new byte[value.Length];
            int indexBA = 0;
            foreach (char item in value.ToCharArray())
            {
                byteArray[indexBA++] = (byte)item;
            }
            //Prepare for compress      
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
            //Compress             
            sw.Write(byteArray, 0, byteArray.Length);
            //Close, DO NOT FLUSH cause bytes will go missing...      
            sw.Close();
            //Transform byte[] zip data to string             
            byteArray = ms.ToArray();
            System.Text.StringBuilder sB = new System.Text.StringBuilder(byteArray.Length);
            foreach (byte item in byteArray)
            {
                sB.Append((char)item);
            }
            ms.Close();
            sw.Dispose();
            ms.Dispose();
            return sB.ToString();
        }

        public static string UnZip(string value)
        {            //Transform string into byte[]     
            byte[] byteArray = new byte[value.Length];
            int indexBA = 0;
            foreach (char item in value.ToCharArray())
            {
                byteArray[indexBA++] = (byte)item;
            }              //Prepare for decompress   
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray);
            System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress);
            //Reset variable to collect uncompressed result         
            byteArray = new byte[byteArray.Length];
            //Decompress        
            int rByte = sr.Read(byteArray, 0, byteArray.Length);
            //Transform byte[] unzip data to string          
            System.Text.StringBuilder sB = new System.Text.StringBuilder(rByte);
            //Read the number of bytes GZipStream red and do not a for each bytes in      
            //resultByteArray;           
            for (int i = 0; i < rByte; i++)
            {
                sB.Append((char)byteArray[i]);
            }
            sr.Close();
            ms.Close();
            sr.Dispose();
            ms.Dispose();
            return sB.ToString();
        }

        public static byte[] CompressGZip(byte[] rawData)
        {
            MemoryStream ms = new MemoryStream();
            GZipOutputStream compressedzipStream = new GZipOutputStream(ms);
            compressedzipStream.Write(rawData, 0, rawData.Length);
            compressedzipStream.Close();
            return ms.ToArray();
        }

        public static byte[] UnGZip(byte[] byteArray)
        {
            GZipInputStream gzi = new GZipInputStream(new MemoryStream(byteArray));
            MemoryStream re = new MemoryStream(50000);
            int count;
            byte[] data = new byte[50000];
            while ((count = gzi.Read(data, 0, data.Length)) != 0)
            { re.Write(data, 0, count); }
            byte[] overarr = re.ToArray();
            return overarr;
        }

        public static string CompressGZip(string value)
        {
            return Convert.ToBase64String(CompressGZip(Encoding.UTF8.GetBytes(value)));
        }

        public static string UnGZip(string value)
        {

            return Encoding.UTF8.GetString(UnGZip(Convert.FromBase64String(value)));
        }
    }

}
