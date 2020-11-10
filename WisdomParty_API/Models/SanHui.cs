using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class SanHui
    {
        //三会一课
        public int Shid    { get; set; }//编号
        public string Shlei   { get; set; }//下拉（三会一课）
        public string ShTitle { get; set; }//标题
        public string HuiYish { get; set; }//会议室
        public DateTime ShKtime { get; set; }//开始时间
        public DateTime ShJtime { get; set; }//结束时间
        public string FuJian  { get; set; }//附件
        public string ShZt { get; set; }//状态（未开始，进行中，已结束，已取消）
    }
}