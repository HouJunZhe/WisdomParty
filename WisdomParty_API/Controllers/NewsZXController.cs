using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WisdomParty_API.DAL;
using WisdomParty_API.Models;

namespace WisdomParty_API.Controllers
{
    //新闻资讯
    [RoutePrefix("newzx")]
    public class NewsZXController : ApiController
    {
        NewsZXDAL dal = new NewsZXDAL();
        //新闻资讯分页
        [HttpGet]
        [Route("zxfy")]
        public IHttpActionResult NewsFenYe(int page, int limit) 
        {
            var list = dal.NewsZXfenye(page, limit);
            int count = 0;
            if (list.ZXcount%limit==0)
            {
                count = list.ZXcount / limit;
            }
            else
            {
                count = list.ZXcount / limit+1;
            }
            return Json(new { fenye=count,data=list});
        }
        //添加新闻资讯
        [HttpPost]
        [Route("zxadd")]
        public IHttpActionResult NewsAdd() 
        {
            ZX z = new ZX();
            var file = HttpContext.Current.Request.Files[0];
            var files = HttpContext.Current.Request.Files[0];
            var zxlei = HttpContext.Current.Request.Form["zxlei"];
            var zxtitle = HttpContext.Current.Request.Form["zxtitle"];
            var zxmiao = HttpContext.Current.Request.Form["zxmiao"];
            var zxnei = HttpContext.Current.Request.Form["zxnei"];
            var zxly = HttpContext.Current.Request.Form["zxly"];
            var zxurl = HttpContext.Current.Request.Form["zxurl"];
            z.Nzxlei = zxlei;
            z.NzxTitle = zxtitle;
            z.Nzmiao = zxmiao;
            z.Nznei = zxnei;
            z.NzxLY = zxly;
            z.Nzurl = zxurl;
            if (file!=null)
            {
                string xd = "/img/" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string jd = HttpContext.Current.Server.MapPath(xd);
                file.SaveAs(jd);
                z.Nzimg = xd;
            }
            if (files!=null)
            {
                string xd = "/img/" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string jd = HttpContext.Current.Server.MapPath(xd);
                file.SaveAs(jd);
                z.NzShiPin = xd;
            }
            var list = dal.NewsZXAdd(z);
            return Json(list);
        }
        //删除
        [HttpPost]
        [Route("zxdel")]
        public IHttpActionResult NewsZXDel(string Id) 
        {
            var list = dal.NewsZXDel(Id);
            return Json(list);
        }
    }
}
