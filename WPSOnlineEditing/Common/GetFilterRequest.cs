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
            try
            {
                result = CheckRequestParam(Request);
                var queryStr = Request.QueryString.ToString();
                // url参数序列化成Dictionary
                //queryStr.Split("&")
                result.Params = queryStr.Split(new char[1] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToDictionary(p => p.Split('=')[0], p => p.Split('=')[1]);
            }
            catch (Exception ex)
            {
                result.code = 10002;
                result.message = ex.Message;
                result.Status = false;
            }

            return result;
        }

        private static RequestParam CheckRequestParam(HttpRequest Request)
        {
            var result = new RequestParam();
            result.FileId = Request.Headers["x-weboffice-file-id"].ToString();
            var queryStr = Request.QueryString.ToString();
            queryStr = queryStr.StartsWith("?") ? queryStr.Substring(1) : queryStr;
            result.Params = queryStr.Split(new char[1] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToDictionary(p => p.Split('=')[0], p => p.Split('=')[1]);
            if (string.IsNullOrEmpty(queryStr) || string.IsNullOrEmpty(result.FileId))
            {
                result.code = 10003;
                result.message = "参数错误，无法打开文件";
                result.Status = false;
            }

            // 此处判断是否传递了自定义的 _w_userId 参数，如果不需要此参数的话可以注释该判断
            if (!result.Params.ContainsKey("_w_userId"))
            {
                result.code = 10004;
                result.message = "用户异常";
                result.Status = false;
            }
            //var token = Request.Headers["x-wps-weboffice-token"];
            //JWTModel jwtModel = JwtHelper.DecodeJwt(token);

            //LogHelper.Default.WriteInfo($"开始进入验证用户过滤器，用户是：{jwtModel.UserName}，过期时间是：{jwtModel.Expiration}");
            //if (jwtModel.UserName != "天玺")
            //{
            //    result.code = 403;
            //    result.message = "用户名错误";
            //    result.Status = false;
            //}

            //if (jwtModel.Expiration < DateTime.Now)
            //{
            //    result.code = 403;
            //    result.message = "Token已经超时";
            //    result.Status = false;
            //}
            return result;
        }
    }
}