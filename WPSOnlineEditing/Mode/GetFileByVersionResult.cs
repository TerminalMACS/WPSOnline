using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{

    public class GetFileByVersionResult : WPSBaseModel
    {
        public GetFileResult file { get; set; }
    }

    /// <summary>
    /// 获取特定版本的文件信息 出参
    /// </summary>
    public class GetFileResult
    {
        /// <summary>
        /// 文件id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public int version { get; set; }

        /// <summary>
        /// 文件大小，单位B
        /// </summary>
        public long size { get; set; }

        /// <summary>
        /// 创建者id，(字符串长度小于40)
        /// </summary>
        public string creator { get; set; }

        /// <summary>
        /// 创建时间的时间戳（单位秒）
        /// </summary>
        public int create_time { get; set; }

        /// <summary>
        /// 修改者id，(字符串长度小于40)
        /// </summary>
        public string modifier { get; set; }

        /// <summary>
        /// 修改时间的时间戳（单位秒）
        /// </summary>
        public int modify_time { get; set; }

        /// <summary>
        /// 下载链接
        /// </summary>
        public string download_url { get; set; }
    }
}
