using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPSOnlineEditing.Common;
using WPSOnlineEditing.Mode;

namespace WPSOnlineEditing.Controllers
{
    [RoutePrefix("v1/jwt")]
    public class JWTController : Controller
    {
        /// <summary>
        /// 创建jwtToken
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [Route("encode"), HttpPost]
        public JsonResult CreateToken(string username,int timeOut)
        {

            DataResult result = new DataResult();

            var jwtModel = new JWTModel();
            jwtModel.UserName = username;
            jwtModel.Expiration = DateTime.Now.AddMilliseconds(timeOut); ;
            result.Token = JwtHelper.EncodeJwt(jwtModel);
            result.Success = true;
            result.Message = "成功";

            return Json(result);
            //get请求需要修改成这样
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}