using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPSOnlineEditing.Mode
{
    /// <summary>
    /// 根据自己业务设定
    /// </summary>
    public class JWTModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}