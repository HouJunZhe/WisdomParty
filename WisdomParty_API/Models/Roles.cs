using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisdomParty_API.Models
{
    public class Roles
    {
        public int Rid   { get; set; }//角色编号
        public string Rname { get; set; }//角色名称
        public string RNei { get; set; }//角色内容
    }
}