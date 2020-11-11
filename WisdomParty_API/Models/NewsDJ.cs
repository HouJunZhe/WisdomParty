using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class NewsDJ
    {
		public List<DJ> dj { get; set; }
		public int DJcount { get; set; }
	}
	public class DJ 
 {
		//党建新闻
		public int Djid { get; set; }//编号
		public string Djlei { get; set; }//（党建新闻）（下拉）
		public string DjTitle { get; set; }//新闻党建标题
		public string Djmiao { get; set; }//描述
		public DateTime DjFaBuRiQi { get; set; }//发布日期
		public string Djimg { get; set; }//封面
		public string DjShiPin { get; set; }//视频
		public string Djnei { get; set; }//内容
		public string DjLY { get; set; }//文章来源
		public string Djurl { get; set; }//原文网址
		public int DjYueDu { get; set; }//阅读
		public int DjDianZan { get; set; }//点赞
	}
}