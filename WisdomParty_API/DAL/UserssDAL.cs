using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.Dal;
using WisdomParty_API.Models;

namespace WisdomParty_API.DAL
{
    public class UserssDAL
    {
        //登录管理员信息JJ
        public Userss UsersDeng(Userss u) 
        {
            string sql = $"select Uid,Uname from Users where Uname='{u.Uname}' and Upwd='{u.Upwd}'";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            Userss uu = JsonConvert.DeserializeObject<List<Userss>>(str).FirstOrDefault();
            return uu;
        }
        //显示系统用户信息
        public List<Userss> UsersXian()
        {
            string sql = "select * from Users";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            List<Userss> u = JsonConvert.DeserializeObject<List<Userss>>(str);
            return u;
        }
        //添加用户信息
        public int UsersAdd(Userss u) 
        {
            string sql = $"insert into Users(Uname,UZhangHao,Upwd) values('{u.Uname}','{u.UZhangHao}','{u.Upwd}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //删除用户信息
        public int UsersDel(string Id) 
        {
            string sql = $"delete from Users where Uid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填用户信息
        public Userss UsersFan(int Id) 
        {
            string sql = $"select * from Users where Uid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            Userss u = JsonConvert.DeserializeObject<List<Userss>>(str).FirstOrDefault();
            return u;
        }
        //修改用户信息
        public int UsersUpd(Userss u) 
        {
            string sql = $"update Users set Uname='{u.Uname}',UZhangHao='{u.UZhangHao}',Upwd='{u.Upwd}' where Uid={u.Uid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //修改用户状态
        public int UsersZt(Userss u) 
        {
            string sql = "";
            if (u.UZt=="正常")
            {
                sql = $"update Users set UZt='禁用' where Uid={u.Uid}";
            }
            else
            {
                sql = $"update Users set UZt='正常' where Uid={u.Uid}";
            }
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //配置角色
        public bool URguanxi(URguanxi u)
        {
            var list = u.Jsid.TrimEnd(',').Split(',');
            List<string> sql = new List<string>();
            sql.Add($"delete from URguanxi where Uhid={u.Uhid}");
            foreach (var m in list)
            {
                sql.Add($"insert into URguanxi(Uhid,Jsid) values({u.Uhid},{m})");
            }
            return DBHelper.ExecuteSqlTran(sql);
        }
    }
}