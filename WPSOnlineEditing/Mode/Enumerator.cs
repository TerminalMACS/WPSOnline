using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WPSOnlineEditing.Mode
{
    public class Enumerator
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public enum ErrorCode
        {
            [Description("系统异常")]
            系统异常 = 10001,

            [Description("参数错误，无法打开文件")]
            无法打开文件=10002,

            [Description("用户ID不能为空")]
            用户为空=10003,

            [Description("文件已存在")]
            文件已存在 = 10004,
        }
    }
}