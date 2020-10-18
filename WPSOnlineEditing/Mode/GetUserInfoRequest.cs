using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    /// <summary>
    /// 1. 获取用户信息 入参model
    /// 2. 通知此文件目前有那些人正在协作 入参model
    /// </summary>
    public class GetUserInfoRequest
    {
        /// <summary>
        /// 用户id数组
        /// </summary>
        public List<string> ids { get; set; }
    }
}
