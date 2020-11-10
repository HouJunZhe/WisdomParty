using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class NewsZX
    {
        public List<ZX> zx { get; set; }//新闻资讯信息
        public int ZXcount { get; set; }//总条数
    }
    public class ZX 
    {
        //新闻资讯表
        public int Nzxid { get; set; }//新闻资讯编号
        public string Nzxlei { get; set; }//（新闻资讯）（下拉）
        public string NzxTitle { get; set; }//标题
        public string Nzmiao { get; set; }//描述
        public DateTime FaBuRiQi { get; set; }//发布时间
        public string Nzimg { get; set; }//新闻资讯封面
        public string NzShiPin { get; set; }//视频
        public string Nznei { get; set; }//内容
        public string NzxLY { get; set; }//文章来源
        public string Nzurl { get; set; }//原文网址
        public int YueDu { get; set; }//阅读
        public int DianZan { get; set; }//点赞
    }
}