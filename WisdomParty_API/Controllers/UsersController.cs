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
    //用户信息
    [RoutePrefix("u")]
    public class UsersController : ApiController
    {
        UserssDAL dal = new UserssDAL();
        //显示用户信息
        [HttpGet]
        [Route("ux")]
        public IHttpActionResult Xian(string name) 
        {
            var list = dal.UsersXian();
            if (string.IsNullOrEmpty(name)==false)
            {
                list = list.Where(m => m.Uname.Contains(name)).ToList();
            }
            return Json(list);
        }
        //添加用户信息
        [HttpPost]
        [Route("uadd")]
        public IHttpActionResult UsersAdd(Userss u) 
        {
            var list = dal.UsersAdd(u);
            return Json(list);
        }
        //删除用户信息
        [HttpPost]
        [Route("udel")]
        public IHttpActionResult UsersDel(string Id) 
        {
            var list = dal.UsersDel(Id);
            return Json(list);
        }
        //修改用户信息
        [HttpPost]
        [Route("uupd")]
        public IHttpActionResult UsersUpd(Userss u) 
        {
            var list = dal.UsersUpd(u);
            return Json(list);
        }
        //反填
        [HttpGet]
        [Route("ufan")]
        public IHttpActionResult UsersFan(int Id) 
        {
            var list = dal.UsersFan(Id);
            return Json(list);
        }
        //登录
        [HttpGet]
        [Route("udeng")]
        public IHttpActionResult UsersDeng(Userss u) 
        {
            var list = dal.UsersDeng(u);
            return Json(list);
        }
        //配置角色
        [HttpPost]
        [Route("js")]
        public IHttpActionResult URguanxi(URguanxi u) 
        {
            var list = dal.URguanxi(u);
            return Json(list);
        }
    }
}
