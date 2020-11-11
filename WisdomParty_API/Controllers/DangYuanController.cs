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
    //党员信息
    [RoutePrefix("dy")]
    public class DangYuanController : ApiController
    {
        DangYuanDAL dal = new DangYuanDAL();
        //分页显示党员信息
        [HttpGet]
        [Route("dyx")]
        public IHttpActionResult DYfenye(int page, int limit) 
        {
            var list = dal.DYfenye(page, limit);
            int count = 0;
            if (list.DYcount%limit==0)
            {
                count = list.DYcount / limit;
            }
            else
            {
                count = list.DYcount / limit + 1;
            }
            return Json(new { yeshu=count,data=list});
        }
        //登录党员信息
        [HttpGet]
        [Route("dydeng")]
        public IHttpActionResult DYdeng(DY d) 
        {
            var list = dal.DYDeng(d);
            return Json(list);
        }
        //添加党员信息
        [HttpPost]
        [Route("dyadd")]
        public IHttpActionResult DYAdd(DY d) 
        {
            var list = dal.DYAdd(d);
            return Json(list);
        }
    }
}
