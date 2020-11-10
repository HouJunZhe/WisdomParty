using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class Userss
    {
        public int Uid       { get; set; }//用户编号
        public string Uname     { get; set; }//用户名称
        public string UZhangHao { get; set; }//用户昵称
        public string Upwd      { get; set; }//用户密码
        public string UZt       { get; set; }//用户状态
        public DateTime CTime     { get; set; }//创建时间
    }
}