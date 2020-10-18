using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPSOnlineEditing.Common;
using WPSOnlineEditing.Mode;

namespace WPSOnlineEditing.Filters
{
    /// <summary>
    /// 用来验证用户授权的过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var token = httpContext.Request.Headers["x-wps-weboffice-token"];
            JWTModel jwtModel = JwtHelper.DecodeJwt(token);

            LogHelper.Default.WriteInfo($"开始进入验证用户过滤器，用户是：{jwtModel.UserName}，过期时间是：{jwtModel.Expiration}");
            if (jwtModel.UserName != "天玺")
            {
                LogHelper.Default.WriteInfo("过滤器返回【false】");
                return false;
            }

            if (jwtModel.Expiration < DateTime.Now)
            {
                LogHelper.Default.WriteInfo("过滤器返回【false】");
                return false;
            }

            //var result = new RequestParam();
            //result.FileId = httpContext.Request.Headers["x-weboffice-file-id"].ToString();
            //var queryStr = httpContext.Request.QueryString.ToString();
            //queryStr = queryStr.StartsWith("?") ? queryStr.Substring(1) : queryStr;
            //if (string.IsNullOrEmpty(queryStr) || string.IsNullOrEmpty(result.FileId))
            //{
            //    return false;
            //}

            //result.Params = queryStr.Split(new char[1] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToDictionary(p => p.Split('=')[0], p => p.Split('=')[1]);

            // 此处判断是否传递了自定义的 _w_userId 参数，如果不需要此参数的话可以注释该判断
            //if (!result.Params.ContainsKey("_w_userId"))
            //{
            //    return false;
            //}
            LogHelper.Default.WriteInfo("过滤器返回【true】");
            return true;
        }
    }
}