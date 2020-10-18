using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    public class GetHistoryRequest
    {
        /// <summary>
        /// 文件id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 记录偏移量
        /// </summary>
        public int offset { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int count { get; set; }
    }

    /// <summary>
    /// 获取历史版本出参
    /// </summary>
    public class GetHistoryResult : WPSBaseModel
    {
        /// <summary>
        /// 历史记录列表
        /// </summary>
        public List<HistroyModel> histories { get; set; }
    }

    public class HistroyModel
    {
        
        /// <summary>
        /// 文件id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 文件名(必须带文件后缀)
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 版本号(位数小于11)
        /// </summary>
        public int version { get; set; }

        /// <summary>
        /// 文件大小，单位B(文件真实大小，否则会出现异常)
        /// </summary>
        public long size { get; set; }

        /// <summary>
        /// 创建时间的时间戳，单位秒
        /// </summary>
        public int create_time { get; set; }

        /// <summary>
        /// 修改时间的时间戳，单位秒
        /// </summary>
        public int modify_time { get; set; }

        /// <summary>
        /// 文件下载url
        /// </summary>
        public string download_url { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        public UserModel creator { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public UserModel modifier { get; set; }
    }
}
