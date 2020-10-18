using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    /// <summary>
    /// 出参
    /// </summary>
    public class UserModelList:WPSBaseModel
    {
        public List<UserModel> users { get; set; }
    }

    /// <summary>
    /// 用户信息MODEL
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 用户id（字符串长度小于32）
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string avatar_url { get; set; }
    }
}
