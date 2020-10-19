using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPSOnlineEditing.Mode;

namespace WPSOnlineEditing.Common
{
    public class GetFilterRequest
    {
        /// <summary>
        /// 获取地址栏中？后面的参数
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static RequestParam GetParams(HttpRequest Request)
        {
            var result = new RequestParam();

            result = CheckRequestParam(Request);
            var queryStr = Request.QueryString.ToString();
            // url参数序列化成Dictionary
            //queryStr.Split("&")
            //result.Params = queryStr.Split(new char[1] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToDictionary(p => p.Split('=')[0], p => p.Split('=')[1]);

            return result;
        }

        private static RequestParam CheckRequestParam(HttpRequest Request)
        {
            var result = new RequestParam();
            result.FileId = Request.Headers["x-weboffice-file-id"].ToString();
            var queryStr = Request.QueryString.ToString();
            Enumerator enumerator = new Enumerator();
            LogHelper.Default.WriteInfo("【queryStr】:" + queryStr);

            queryStr = queryStr.StartsWith("?") ? queryStr.Substring(1) : queryStr;
            result.Params = queryStr.Split(new char[1] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToDictionary(p => p.Split('=')[0], p => p.Split('=')[1]);
            if (string.IsNullOrEmpty(queryStr) || string.IsNullOrEmpty(result.FileId))
            {
                result.code = (int)Enumerator.ErrorCode.无法打开文件;
                result.message = EnumExtension.GetDescription(Enumerator.ErrorCode.无法打开文件);
                result.Status = false;
            }

            // 此处判断是否传递了自定义的 _w_userId 参数，如果不需要此参数的话可以注释该判断
            if (!result.Params.ContainsKey("_w_userId"))
            {
                result.code = (int)Enumerator.ErrorCode.用户为空;
                result.message = EnumExtension.GetDescription(Enumerator.ErrorCode.用户为空);
                result.Status = false;
            }

            #region Token判断，目前因为wps回调接口没有带token，所以有些异常

            //var token = Request.Headers["x-wps-weboffice-token"];
            //if (string.IsNullOrWhiteSpace(token))
            //{
            //    token = result.Params["access_token"];
            //    LogHelper.Default.WriteInfo("token:"+token);
            //}

            //if (!string.IsNullOrEmpty(token))
            //{
            //    JWTModel jwtModel = JwtHelper.DecodeJwt(token);

            //    LogHelper.Default.WriteInfo($"开始进入验证用户过滤器，用户是：{jwtModel.UserName}，过期时间是：{jwtModel.Expiration}");
            //    if (jwtModel.UserName != "天玺")
            //    {
            //        result.code = 403;
            //        result.message = "用户名错误";
            //        result.Status = false;
            //    }

            //    if (jwtModel.Expiration < DateTime.Now)
            //    {
            //        result.code = 403;
            //        result.message = "Token已经超时";
            //        result.Status = false;
            //    }
            //}
            //else
            //{
            //    LogHelper.Default.WriteError("token为空");
            //}

            #endregion

            return result;
        }
    }
}