using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class KaoShi
    {
        //在线考试
        public int KSid       { get; set; }//编号
        public string KSname     { get; set; }//考试名称
        public DateTime KSkaishi   { get; set; }//开始日期
        public DateTime KSjiezhi   { get; set; }//截止日期
        public string KSshuoming { get; set; }//考试说明
        public DateTime DTtime     { get; set; }//答题时间
        public int TMNum      { get; set; }//题目数量
        public string XZtimu { get; set; }//单选（随机生成、手动选题）
    }
}