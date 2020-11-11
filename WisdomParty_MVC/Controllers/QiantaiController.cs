using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WisdomParty_MVC.Controllers
{
    public class QiantaiController : Controller
    { 
        //主页
        public ActionResult Homepage()
        {
            return View();
        }
        //登录
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            return View();
        }
    }
}