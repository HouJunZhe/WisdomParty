using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class DangYuan
    {
        public List<DY> dy { get; set; }//党员信息
        public int DYcount { get; set; }//总条数
    }
    public class DY 
    {
        public int DYid { get; set; }//党员编号
        public string DYweixin { get; set; }//微信名称
        public string DYname { get; set; }//党员名称
        public string DYhao { get; set; }//党员手机号
        public string DYpwd { get; set; }//党员密码
        public string DYgonghao { get; set; }//党员工号
        public string DYsex { get; set; }//(男，女，未知)
        public string DYchusheng { get; set; }//党员出生年月
        public string DYxueli { get; set; }//党员学历
        public DateTime DYrudang { get; set; }//--入党时间
        public string DYzhibu { get; set; }//党员所属支部
        public int DYjifen { get; set; }//党员积分
    }
}