using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSOnlineEditing.Mode
{
    public class FileInfoResult : WPSBaseModel
    {
        /// <summary>
        /// 文件
        /// </summary>
        public WPSFile file { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UserForFile user { get; set; }
    }

    /// <summary>
    /// 文件MODEL
    /// </summary>
    public class WPSFile
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
        /// 创建者id，字符串长度小于40
        /// </summary>
        public string creator { get; set; }

        /// <summary>
        /// 创建时间的时间戳，单位秒
        /// </summary>
        public int create_time { get; set; }

        /// <summary>
        /// 修改者id，字符串长度小于40
        /// </summary>
        public string modifier { get; set; }

        /// <summary>
        /// 修改时间的时间戳，单位秒
        /// </summary>
        public int modify_time { get; set; }

        /// <summary>
        /// 文件下载url
        /// </summary>
        public string download_url { get; set; }

        /// <summary>
        /// 用户权限控制配置
        /// </summary>
        public User_acl user_acl { get; set; }

        /// <summary>
        /// 水印配置
        /// </summary>
        public Watermark watermark { get; set; }
    }

    /// <summary>
    /// 用户权限控制
    /// </summary>
    public class User_acl
    {
        /// <summary>
        /// 是否允许重命名，1：是 0：否
        /// </summary>
        public int rename { get; set; }

        /// <summary>
        /// 是否允许查看历史记录，1：是 0：否
        /// </summary>
        public int history { get; set; }

        /// <summary>
        /// 是否允许复制，1：是 0：否
        /// </summary>
        public int copy { get; set; }

        /// <summary>
        /// 是否允许导出，1：是 0：否
        /// </summary>
        public int export { get; set; }

        /// <summary>
        /// 是否允许打印，1：是 0：否
        /// </summary>
        public string print { get; set; }
    }

    public class Watermark
    {
        /// <summary>
        /// 是否有水印， 1：有 0：无
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 水印字符串(当type为1时此字段必选)
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 水印的透明度(非必选，有默认值):"rgba( 192, 192, 192, 0.6 )"
        /// </summary>
        public string fillstyle { get; set; }

        /// <summary>
        /// 水印的字体(非必选，有默认值):"bold 20px Serif"
        /// </summary>
        public string font { get; set; }

        /// <summary>
        /// 水印的旋转度(非必选，有默认值):-0.7853982
        /// </summary>
        public decimal rotate { get; set; }

        /// <summary>
        /// 水印水平间距(非必选，有默认值):
        /// </summary>
        public int horizontal { get; set; }


        /// <summary>
        /// 水印垂直间距(非必选，有默认值)
        /// </summary>
        public int vertical { get; set; }
    }


    /// <summary>
    /// 用户对于此文件的信息
    /// </summary>
    public class UserForFile
    {
        /// <summary>
        /// 用户id(长度小于32)
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户对文件的权限，只能取 “read” 和 “write” 两个字符串，表示只读和可修改
        /// </summary>
        public string permission { get; set; }

        /// <summary>
        /// 用户头像url
        /// </summary>
        public string avatar_url { get; set; }
    }
}
