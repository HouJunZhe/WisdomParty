using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class TK
    {
        public List<TiKu> tk { get; set; }///教育信息
        public int TKcount { get; set; }//总条数
    }
    public class TiKu
    {
        //考试题库
        public int TKid        { get; set; }//编号
        public string TKfenlei    { get; set; }//下拉（在线考试、活动报名、问卷调查）
        public string TKname      { get; set; }//题库名称
        public string TKleixing   { get; set; }//下拉（单选题、多选题、问答题）
        public string TKxuanxiang { get; set; }//（根据题目类型添加题目选项）
        public string TKqita      { get; set; }//其他答案
        public string TKlaiyuan   { get; set; }//题目来源
        public string TKimg       { get; set; }//题目图片
        public string TKshipin    { get; set; }//视频
        public DateTime TKtime { get; set; }//创建时间
    }
}