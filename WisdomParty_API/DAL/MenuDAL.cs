using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.Dal;
using WisdomParty_API.Models;

namespace WisdomParty_API.DAL
{
    public class MenuDAL
    {
        //显示菜单信息
        public List<Menu> MenuXian() 
        {
            string sql = "select * from Menu order by Mpaixu";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            List<Menu> m = JsonConvert.DeserializeObject<List<Menu>>(str);
            return m;
        }
        //根据菜单Id显示子类信息
        public List<Menu> MenuXianZiLei(int Id) 
        {
            string sql = $"select * from Menu  where Pid={Id} order by Mpaixu";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            List<Menu> m = JsonConvert.DeserializeObject<List<Menu>>(str);
            return m;
        }
        //添加菜单信息
        public int MenuAdd(Menu m) 
        {
            string sql = $"insert into Menu values({m.Pid},'{m.Mname}','{m.Murl}','{m.Mioc}','{m.MYanSe}',{m.Mpaixu})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //删除菜单信息
        public int MenuDel(string Id) 
        {
            string sql = $"delete from Menu where Mid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //修改菜单信息
        public int MenuUpd(Menu m) 
        {
            string sql = $"update Menu set Pid={m.Pid},Mname='{m.Mname}',Murl='{m.Murl}',Mioc='{m.Mioc}',MYanSe='{m.MYanSe}',Mpaixu={m.Mpaixu} where Mid={m.Mid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填菜单信息
        public Menu MenuFan(int Id) 
        {
            string sql = $"select * from Menu order by Mpaixu where Mid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            Menu m = JsonConvert.DeserializeObject<List<Menu>>(str).FirstOrDefault();
            return m;
        }
    }
}