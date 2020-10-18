using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    /// <summary>
    /// 新建文件 入参
    /// </summary>
    public class CreateWPSFileRequest
    {
        /// <summary>
        /// 新建文件名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 新的文件
        /// </summary>
        /// todo: 实际使用中再次更改
        public object file { get; set; }
    }

    /// <summary>
    /// 新建文件 出参
    /// </summary>
    public class CreateWPSFileResult : WPSBaseModel
    {
        /// <summary>
        /// 一个可以访问到新创建文档的url
        /// </summary>
        // 官方给出的url样例是这样的：http://wwo.wps.cn/office/w/<:fileid>?_w_fname=example.doc&_w_userid=1000&_w_appid=xxx&_w_signature=xxx 需要签名
        public string redirect_url { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        public string user_id { get; set; }
    }
}
