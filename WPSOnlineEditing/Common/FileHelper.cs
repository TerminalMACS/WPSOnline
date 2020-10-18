using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WPSOnlineEditing.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 获取文件夹/文件的大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static long FileSize(string filePath)
        {
            long temp = 0;

            //判断当前路径所指向的是否为文件
            if (File.Exists(filePath) == false)
            {
                string[] str1 = Directory.GetFileSystemEntries(filePath);
                foreach (string s1 in str1)
                {
                    temp += FileSize(s1);
                }
            }
            else
            {
                //定义一个FileInfo对象,使之与filePath所指向的文件向关联,

                //以获取其大小
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
            return temp;
        }

    }
}