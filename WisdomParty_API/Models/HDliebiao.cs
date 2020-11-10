using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class HDliebiao
    {
        //活动列表
        public int HDlbid   { get; set; }//编号
        public string HDtitle  { get; set; }//活动标题
        public string HDdizhi  { get; set; }//活动地址
        public DateTime HDkaishi { get; set; }//开始时间
        public DateTime HDjieshu { get; set; }//结束时间
        public DateTime HDjiezhi { get; set; }//报名截止
        public string HDrenshu { get; set; }//人数上限
        public string HDZt     { get; set; }//状态（报名中、待开始、进行中、已结束、已取消）
        public string HDimg    { get; set; }//活动封面
        public string HDnei { get; set; }//活动内容
    }
}