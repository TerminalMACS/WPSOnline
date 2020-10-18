using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    public class WPSBaseModel
    {
        /// <summary>
        /// 错误编码：40005
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息：InvalidArgument
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 明细：参数错误
        /// </summary>
        public string details { get; set; }

        /// <summary>
        /// 提示：参数错误
        /// </summary>
        public string hint { get; set; }
    }
}
