﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WPSOnlineEditing.Mode.WPSEnum;

namespace WPSOnlineEditing.Mode
{
    /// <summary>
    /// 生成WPS的iframe url的入参，可以自己扩展参数，然后放到DIctionary中进行签名
    /// </summary>
    public class GenarateRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 文件id
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public FileType FileType { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        public string ReadOnly { get; set; }
    }

    /// <summary>
    /// 出参
    /// </summary>
    public class GenarateResult
    {
        public string Url { get; set; }
    }
}
