using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class JiaoFei
    {
        //党员缴费表
        public int JFid      { get; set; }//编号
        public int JFyhid    { get; set; }//（缴费用户（党员信息的外键））
        public string JFdanhao  { get; set; }//缴费单号
        public int JFnianfen { get; set; }//缴费年份
        public int JFyuefen  { get; set; }//缴费月份
        public double JFmoney   { get; set; }//缴费金额
        public DateTime JFSCtime  { get; set; }//上传日期
        public string JFZT      { get; set; }//缴费状态（待缴，已付，已缴）
        public string JFnei     { get; set; }//缴费内容
        public DateTime JFtime { get; set; }//缴费时间
    }
}