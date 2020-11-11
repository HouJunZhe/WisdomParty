using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WisdomParty_MVC.Controllers
{
    public class NewsZXController : Controller
    {
        //显示新闻资讯信息
        // GET: NewsZX
        public ActionResult Index()
        {
            return View();
        }
        //添加新闻资讯
        public ActionResult Add() 
        {
            return View();
        }
    }
}