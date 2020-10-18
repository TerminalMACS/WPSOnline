using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    public class WPSEnum
    {
        /// <summary>
        /// 文件类型枚举
        /// </summary>
        public enum FileType
        {
            /// <summary>
            /// 表格文件
            /// </summary>
            s = 0,

            /// <summary>
            /// 文字文件
            /// </summary>
            w = 1,

            /// <summary>
            /// 演示文件
            /// </summary>
            p = 2,

            /// <summary>
            /// PDF文件
            /// </summary>
            f = 3
        }
    }
}
