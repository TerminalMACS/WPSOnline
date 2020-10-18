using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPSOnlineEditing.Common;
using WPSOnlineEditing.Filters;
using WPSOnlineEditing.Mode;

namespace WPSOnlineEditing.Controllers
{
    [RoutePrefix("v1/3rd")]
    public class WPSInterfaceController : Controller
    {
        LogHelper _log = null;
        public WPSInterfaceController()
        {
            _log = LogHelper.Default;
        }

        #region 生成iframe用的url
        /// <summary>
        /// 生成iframe用的url（此方法非WPS官方的，主要是为了签名，也可以自己实现）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("wps/genarate"), HttpPost]
        public JsonResult GenarateWPSUrl(GenarateRequest request)
        {
            var url = WPSSignatureHelper.GenarateUrl(request.FileId,
                                            request.FileType,
                                            new Dictionary<string, string> {
                                                    { "_w_userId", request.UserId },
                                                    { "_w_fileName", request.FileName }
                                            });
            // 上面的写法是在生成的url中带了两个自定义参数 _w_userId 和 _w_fileName，可以根据业务自己扩展，生成url是这样的：
            // https://wwo.wps.cn/office/w/123?_w_appid=123456&_w_fileName=x.docx&_w_userId=5024&_w_signature=xxxxx


            // 也可以不写自定义参数，这样生成的url会只有 _w_appId 和 _w_ signatrue，例如：https://wwo.wps.cn/office/w/123?_w_appid=123456&_w_signature=xxxxx
            //var url = WPSHelper.GenarateUrl(request.FileId,request.FileType);

            return Json(new GenarateResult { Url = url });
        }
        #endregion

        #region WPS开放平台要求实现接口
        /// <summary>
        /// 获取文件元数据
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("file/info")]
        public JsonResult FileInfo()
        {
            _log.WriteInfo("开始请求接口【file/info】");
            FileInfoResult result = new FileInfoResult();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;

                }
                else
                {
                    // 获取自定义参数
                    var userId = request.Params["_w_userId"].ToString();//用户ID
                    var fileId = request.FileId;//文件ID

                    #region >>>从数据库查询用户名、文件 等信息......<<<

                    #endregion

                    #region >>>示例<<<
                    // 创建时间和修改时间默认全是现在，可更改，但是注意时间戳是11位的（秒）
                    var now = TimestampHelper.GetCurrentTimestamp();
                    var fileName = request.FileId == "1000" ? "TestFile.docx" : (request.FileId == "1001" ? "TestFile_v1.docx" : "TestFile_v2.docx");
                    int version = request.FileId == "1000" ? 5 : (request.FileId == "1001" ? 1 : 2);
                    string filePath = Server.MapPath($"/Files/{fileName}");
                    result.file = new WPSFile
                    {
                        id = "1000",
                        name = "TestFile.docx",
                        // 如果线下修改后将修改此版本重新上传
                        version = 5,
                        size = FileHelper.FileSize(filePath), // WPS单位是B
                        create_time = now,
                        creator = "天玺",
                        modify_time = now,
                        modifier = "天玺",
                        download_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Files/{fileName}",
                        user_acl = new User_acl
                        {
                            history = 1, // 允许查看历史版本
                            rename = 1, // 允许重命名
                            copy = 1, // 允许复制
                            export = 1,
                        },
                        watermark = new Watermark
                        {
                            type = 1, // 1为有水印
                            value = "水印文字"
                        }
                    };
                    result.user = new UserForFile()
                    {
                        id = "1000",
                        name = "天玺",
                        //permission = "read",
                        permission = "write", // write为允许编辑，read为只能查看
                        avatar_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Images/photo1.jpg",
                    };
                    #endregion
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }

            _log.WriteInfo("请求接口【file/info】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [Route("user/info"), HttpPost]
        public JsonResult GetUserInfo(GetUserInfoRequest body)
        {
            _log.WriteInfo("开始请求接口【user/info】");
            UserModelList result = new UserModelList();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;
                }
                else
                {
                    result.users = new List<UserModel>();
                    result.users.Add(new UserModel
                    {
                        id = "518329384",
                        name = "天玺",
                        avatar_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Images/photo1.jpg",
                    });
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }
            _log.WriteInfo("请求接口【user/info】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }

        /// <summary>
        /// 通知此文件目前有哪些人正在协作
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [Route("file/online"), HttpPost]
        public JsonResult Online(GetUserInfoRequest body)
        {
            _log.WriteInfo("开始请求接口【file/online】");
            WPSBaseModel result = new WPSBaseModel();
            try
            {
                result.code = 200;
                result.message = "success";
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }
            _log.WriteInfo("请求接口【file/online】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }

        /// <summary>
        /// 上传文件新版本（保存文件）
        /// </summary>
        /// <param name="file">传来的文件流</param>
        /// <returns></returns>
        [Route("file/save"), HttpPost]
        public JsonResult SaveFile()
        {
            _log.WriteInfo("开始请求接口【file/save】");
            SaveFileResult result = new SaveFileResult();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;
                }
                else
                {
                    var fileName = request.FileId == "1000" ? "TestFile.docx" : (request.FileId == "1001" ? "TestFile_v1.docx" : "TestFile_v2.docx");
                    HttpFileCollection files = HttpContext.ApplicationInstance.Request.Files;
                    foreach (string key in files.AllKeys)
                    {
                        HttpPostedFile file = files[key];
                        if (string.IsNullOrEmpty(file.FileName) == false)
                            file.SaveAs(Server.MapPath("~/Files/") + fileName);
                    }

                    result.file = new WPSFileModel
                    {
                        download_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Files/{fileName}",
                        id = request.FileId,
                        name = request.Params["_w_fileName"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }
            _log.WriteInfo("请求接口【file/save】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }

        /// <summary>
        /// 获取特定版本的文件信息
        /// </summary>
        /// <param name="version">版本号</param>
        /// <returns></returns>
        [Route("file/version/{version}"), HttpGet]
        public JsonResult Version(int version)
        {
            _log.WriteInfo("开始请求接口【file/version】");
            GetFileByVersionResult result = new GetFileByVersionResult();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;
                }
                else
                {
                    // 从数据库查询文件信息......

                    // 创建时间和修改时间默认全是现在

                    var now = TimestampHelper.GetCurrentTimestamp();
                    var fileName = request.FileId == "1000" ? "TestFile.docx" : (request.FileId == "1001" ? "TestFile_v1.docx" : "TestFile_v2.docx");
                    string filePath = Server.MapPath($"/Files/{fileName}");
                    result.file = new GetFileResult
                    {
                        id = request.FileId,
                        name = fileName,
                        version = version,
                        size = FileHelper.FileSize(filePath), // WPS单位是B,
                        create_time = now,
                        creator = "天玺",
                        modify_time = now,
                        modifier = "天玺",
                        download_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Files/{fileName}"
                    };
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }
            _log.WriteInfo("请求接口【file/version】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="body">包含一个name的字符串属性，值为保存的新文件名</param>
        /// <returns></returns>
        [Route("file/rename"), HttpPut]
        public JsonResult RenameFile(RenameFileRequest body)
        {
            _log.WriteInfo("开始请求接口【file/rename】");
            WPSBaseModel result = new WPSBaseModel();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;
                }
                else
                {
                    result.code = 200;
                    result.message = "success";
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }
            _log.WriteInfo("请求接口【file/rename】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }

        /// <summary>
        /// 获取所有历史版本文件信息
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [Route("file/history"), HttpPost]
        public JsonResult GetHistory(GetHistoryRequest body)
        {
            _log.WriteInfo("开始请求接口【file/history】");
            GetHistoryResult result = new GetHistoryResult();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;
                }
                else
                {
                    // 从数据库查询用户、文件信息等......

                    // 创建时间和修改时间默认全是现在
                    //var now = TimestampHelper.GetCurrentTimestamp();

                    var startNow = TimestampHelper.ConvertToTimeStamp(DateTime.Now.AddHours(-10));
                    // 不需要使用历史版本功能的此处也请返回，如果此接口不通时，文档加载会报错：“GetFileInfoFailed”
                    result.histories = new List<HistroyModel>
                    {
                        new HistroyModel
                        {
                             id="1001",
                             name="TestFile_v1.docx",
                             size=FileHelper.FileSize(Server.MapPath("/Files/TestFile_v1.docx")), // 单位B
                             version=1,
                             download_url=$"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Files/TestFile_v1.docx",
                             create_time=startNow,
                             modify_time=startNow,
                             creator=new UserModel
                             {
                                 id="1001",
                                 name="兆丰",
                                 avatar_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Images/photo2.jpg"
                             },
                             modifier=new UserModel
                             {
                                id="1001",
                                name="兆丰",
                                avatar_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Images/photo2.jpg"
                             }
                        },
                        new HistroyModel
                        {
                             id="1002",
                             name="TestFile_v2.docx",
                             size=FileHelper.FileSize(Server.MapPath("/Files/TestFile_v2.docx")), // 单位B
                             version=2,
                             download_url=$"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Files/TestFile_v2.docx",
                             create_time=startNow,
                             modify_time=startNow,
                             creator=new UserModel
                             {
                                 id="1002",
                                 name="丫丫",
                                 avatar_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Images/photo3.jpg"
                             },
                             modifier=new UserModel
                             {
                                id="1002",
                                name="丫丫",
                                avatar_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Images/photo3.jpg"
                             }
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }

            _log.WriteInfo("请求接口【file/history】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }

        /// <summary>
        /// 新建文件
        /// </summary>
        /// <returns></returns>
        [Route("file/new"), HttpPost]
        public JsonResult NewFile(CreateWPSFileRequest request)
        {
            _log.WriteInfo("开始请求接口【file/new】");
            var result = new CreateWPSFileResult();
            try
            {
                var filterRequest = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!filterRequest.Status)
                {
                    result.code = filterRequest.code;
                    result.message = filterRequest.message;
                }
                else
                {
                    if (!filterRequest.Status)
                    {
                        return Json(new CreateWPSFileResult { code = filterRequest.code, message = filterRequest.message });
                    }

                    HttpFileCollection files = HttpContext.ApplicationInstance.Request.Files;
                    string fileName = Guid.NewGuid().ToString("N") + ".docx";
                    foreach (string key in files.AllKeys)
                    {
                        HttpPostedFile file = files[key];
                        if (string.IsNullOrEmpty(file.FileName) == false)
                            file.SaveAs(Server.MapPath("~/Files/") + fileName);
                    }

                    result.redirect_url = $"{ConfigurationManager.AppSettings["WPSTokenUrl"]}/Files/{fileName}";
                    result.user_id = "1000";
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }

            _log.WriteInfo("请求接口【file/new】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }

        /// <summary>
        /// 回调通知
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [Route("onnotify"), HttpPost]
        public JsonResult WPSNotify(WPSNotifyRequest body)
        {
            _log.WriteInfo("开始请求接口【onnotify】");
            WPSBaseModel result = new WPSBaseModel();
            try
            {
                var request = GetFilterRequest.GetParams(HttpContext.ApplicationInstance.Request);
                if (!request.Status)
                {
                    result.code = request.code;
                    result.message = request.message;
                }
                else
                {
                    result.code = 200;
                    result.message = "success";
                }
            }
            catch (Exception ex)
            {
                result.code = 10001;
                result.message = ex.Message;
            }

            _log.WriteInfo("请求接口【onnotify】完成,返回数据：" + JsonConvert.SerializeObject(result));
            return Json(result);
        }
        #endregion
    }
}