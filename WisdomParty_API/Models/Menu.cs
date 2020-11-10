using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class Menu
    {
        public int Mid   { get; set; }//菜单编号
        public int Pid { get; set; }//父级编号
        public string Mname { get; set; }//菜单名称
        public string Murl  { get; set; }//菜单链接
        public string Mioc  { get; set; }//菜单ioc
        public string MYanSe { get; set; }//图标颜色
        public int Mpaixu { get; set; }//排序
    }
}