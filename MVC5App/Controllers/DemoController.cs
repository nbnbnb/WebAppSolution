using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5App.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxDemos()
        {
            return View();
        }

        public ActionResult ShowTime()
        {
            return Content("ShowTime: " + DateTime.Now.ToString());
        }

        public ActionResult MockLogin()
        {
            return JavaScript("alert('登录成功');");
        }

        public ActionResult SearchUser()
        {
            return PartialView("AllUsersPartial");
        }

        public ActionResult CustomValidator()
        {
            // 在 Model 的绑定过程中，同时也会执行数据验证
            // 数据验证信息存储在 ModelState 中
            return View();
        }
    }
}