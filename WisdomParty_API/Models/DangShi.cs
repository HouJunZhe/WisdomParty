using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class DangShi
    {
        //党史人物
        public int Dsid       { get; set; }//编号
        public string Dslei      { get; set; }//下拉（党史人物）
        public string DsTitle    { get; set; }//标题
        public string Dsmiao     { get; set; }//描述
        public DateTime DsFaBuRiQi { get; set; }//发布日期
        public string Dsimg      { get; set; }//封面
        public string DsShiPin   { get; set; }//视频
        public string Dsnei      { get; set; }//内容
        public string DsjLY      { get; set; }//文章来源
        public string Dsurl      { get; set; }//原文网址
        public int DsYueDu    { get; set; }//阅读
        public int DsDianZan { get; set; }//点赞
    }
}