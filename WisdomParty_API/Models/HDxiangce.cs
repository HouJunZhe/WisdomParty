using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class HDxiangce
    {
        //活动相册
        public int XZid    { get; set; }//编号
        public string XZname  { get; set; }//相册名称
        public string XZtitle { get; set; }//相册标签
        public string XZnei   { get; set; }//相册摘要
        public string XZimg { get; set; }//相册图片
    }
}