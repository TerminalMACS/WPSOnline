using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    /// <summary>
    /// 上传文件新版本
    /// </summary>
    public class SaveFileResult:WPSBaseModel
    {
        /// <summary>
        /// 文件信息
        /// </summary>
        public WPSFileModel file { get; set; }
    }

    /// <summary>
    /// 文件model
    /// </summary>
    public class WPSFileModel
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
        /// 版本号(位数小于11)
        /// </summary>
        public int version { get; set; }

        /// <summary>
        /// 文件大小，单位B
        /// </summary> 
        public int size { get; set; }

        /// <summary>
        /// 下载链接
        /// </summary>
        public string download_url { get; set; }
    }
}
