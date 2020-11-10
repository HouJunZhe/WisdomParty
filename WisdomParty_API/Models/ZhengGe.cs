using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class ZhengGe
    {
        //政策法规表
        public int ZGid       { get; set; }//编号
        public string ZGlei      { get; set; }//下拉（政策法规）
        public string ZGTitle    { get; set; }//标题
        public string ZGmiao     { get; set; }//描述
        public DateTime ZGFaBuRiQi { get; set; }//发布日期
        public string ZGimg      { get; set; }//封面
        public string ZGShiPin   { get; set; }//视频
        public string ZGnei      { get; set; }//内容
        public string ZGjLY      { get; set; }//文章来源
        public string ZGurl      { get; set; }//原文网址
        public int ZGYueDu    { get; set; }//阅读
        public int ZGDianZan { get; set; }//点赞
    }
}