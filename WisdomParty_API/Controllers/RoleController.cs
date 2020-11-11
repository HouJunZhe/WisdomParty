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
    //角色信息
    [RoutePrefix("r")]
    public class RoleController : ApiController
    {
        RolesDAL dal = new RolesDAL();
        //显示角色信息
        [HttpGet]
        [Route("rx")]
        public IHttpActionResult RoleXian(string name) 
        {
            var list = dal.RoleXian();
            //根据角色名称查询
            if (string.IsNullOrEmpty(name)==false)
            {
                list = list.Where(m => m.Rname.Contains(name)).ToList();
            }
            return Json(list);
        }
        //添加角色信息
        [HttpPost]
        [Route("radd")]
        public IHttpActionResult RoleAdd(Roles r) 
        {
            var list = dal.RoleAdd(r);
            return Json(list);
        }
        //删除角色信息
        [HttpPost]
        [Route("rdel")]
        public IHttpActionResult RoleDel(string Id) 
        {
            var list = dal.RoleDel(Id);
            return Json(list);
        }
        //修改角色信息
        [HttpPost]
        [Route("rupd")]
        public IHttpActionResult RoleUpd(Roles r) 
        {
            var list = dal.RoleUpd(r);
            return Json(list);
        }
        //配置菜单
        [HttpPost]
        [Route("jc")]
        public IHttpActionResult RMguanxi(RMguanxi r) 
        {
            var list = dal.RMguanxi(r);
            return Json(list);
        }
        //反填
        [HttpGet]
        [Route("rfan")]
        public IHttpActionResult RoleFan(int Id) 
        {
            var list = dal.RolesFan(Id);
            return Json(list);
        }
    }
}
