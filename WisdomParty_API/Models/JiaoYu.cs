using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class JY
    {
        public List<JiaoYu> jy { get; set; }///教育信息
        public int JYcount { get; set; }//总条数
    }
    public class JiaoYu
    {
        //专题教育
        public int JYid       { get; set; }//编号
        public string JYlei      { get; set; }//下拉(八项规定、两学一做、三严三实、三会一课)
        public string JYTitle    { get; set; }//标题
        public string JYmiao     { get; set; }//描述
        public DateTime JYFaBuRiQi { get; set; }//发布日期
        public string JYimg      { get; set; }//封面
        public string JYShiPin   { get; set; }//视频
        public string JYnei      { get; set; }//内容
        public string JYjLY      { get; set; }//文章来源
        public string JYurl      { get; set; }//原文网址
        public int JYYueDu    { get; set; }//阅读
        public int JYDianZan { get; set; }//点赞
    }
}