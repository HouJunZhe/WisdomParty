using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WisdomParty_API.DAL;
using WisdomParty_API.Models;

namespace WisdomParty_API.Controllers
{
    //菜单信息
    [RoutePrefix("m")]
    public class MenuController : ApiController
    {
        MenuDAL dal = new MenuDAL();
        //显示菜单信息
        [HttpGet]
        [Route("mx")]
        public IHttpActionResult MXian()
        {
            var list = dal.MenuXian();
            return Json(list);
        }
        //根据菜单Id显示子类信息
        [HttpGet]
        [Route("zl")]
        public IHttpActionResult MenuXianZiLei(int Id)
        {
            var list = dal.MenuXianZiLei(Id);
            return Json(list);
        }
        //添加菜单
        [HttpPost]
        [Route("madd")]
        public IHttpActionResult MenuAdd(Menu m)
        {
            var list = dal.MenuAdd(m);
            return Json(list);
        }
        //删除菜单
        [HttpPost]
        [Route("mdel")]
        public IHttpActionResult MenuDel(string Id)
        {
            var list = dal.MenuDel(Id);
            return Json(list);
        }
        //修改菜单
        [HttpPost]
        [Route("mupd")]
        public IHttpActionResult MenuUpd(Menu m)
        {
            var list = dal.MenuUpd(m);
            return Json(list);
        }
        //反填
        [HttpGet]
        [Route("mfan")]
        public IHttpActionResult MenuFan(int Id)
        {
            var list = dal.MenuFan(Id);
            return Json(list);
        }
    }
}
