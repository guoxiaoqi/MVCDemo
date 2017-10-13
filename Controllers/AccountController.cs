using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前。。。";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            //获取表单数据
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];

            //进行下一步处理，这里先改下文字
            ViewBag.LoginState =email + "登录后。。。";
            return View();
        }
 
        public ActionResult Register()
        {
            ViewBag.Register = "注册前。。。";
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection fc)
        {
            //获取表单数据
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];

            //进行下一步处理，这里先改下文字
            ViewBag.LoginState =  "注册账号 "+email;
            return View();
        }

    }
}