using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WPSOnlineEditing.Mode
{
    public class Enumerator
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public enum ErrorCode
        {
            //[Description("系统异常")]
            //系统异常 = 10001,

            //[Description("参数错误，无法打开文件")]
            //无法打开文件=10002,

            //[Description("用户ID不能为空")]
            //用户为空=10003,

            //[Description("文件已存在")]
            //文件已存在 = 10004,
            [Description("服务处理正常")]
            OK=0,
            [Description("用户未登录")]
            UserNotLogin = 40001,
            [Description("token过期")]
            SessionExpired = 4002,
            [Description("用户无权限访问")]
            PermissionDenied = 4003,
            [Description("资源不存在")]
            NotExists = 40004,
            [Description("参数错误")]
            InvalidArgument = 4005,
            [Description("保存空间已满")]
            SpaceFull = 40006,
            [Description("自定义错误提示，前端页面将显示此错误内容")]
            CustomMsg = 40007,
            [Description("文件重命名冲突")]
            FnameConflict = 40008,
            [Description("系统内部错误")]
            ServerError = 50001,
        }
    }
}