using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WPSOnlineEditing.Controllers
{
    public class WPSOnlineController : Controller
    {
        // GET: WPSOnline
        public ActionResult Index()
        {
            //ViewBag.Title = "在线编辑";
            //ViewBag.Message = "测试";
            return View();
        }
    }
}