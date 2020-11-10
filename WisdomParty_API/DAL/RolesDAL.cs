using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.Dal;
using WisdomParty_API.Models;

namespace WisdomParty_API.DAL
{
    public class RolesDAL
    {
        //显示角色信息
        public List<Roles> RoleXian() 
        {
            string sql = "select * from Roles";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            List<Roles> r = JsonConvert.DeserializeObject<List<Roles>>(str);
            return r;
        }
        //添加角色信息
        public int RoleAdd(Roles r) 
        {
            string sql = $"insert into Roles values('{r.Rname}','{r.RNei}')";
            return DBHelper.ExecuteNonQuery(sql,System.Data.CommandType.Text);
        }
        //删除角色信息
        public int RoleDel(string Id) 
        {
            string sql = $"delete from Roles where Rid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //修改角色信息
        public int RoleUpd(Roles r) 
        {
            string sql = $"update Roles set Rname='{r.Rname}',RNei='{r.RNei}' where Rid={r.Rid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填
        public Roles RolesFan(int Id) 
        {
            string sql = $"select * from Roles where Rid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            Roles r = JsonConvert.DeserializeObject<List<Roles>>(str).FirstOrDefault();
            return r;
        }
        //配置菜单
        public bool RMguanxi(RMguanxi r) 
        {
            var list = r.Mcid.TrimEnd(',').Split(',');
            List<string> sql = new List<string>();
            sql.Add($"delete from JMguanxi where Rjsid={r.Rjsid}");
            foreach (var m in list)
            {
                sql.Add($"insert into JMguanxi(Rjsid,Mcid) values({r.Rjsid},{m})");
            }
            return DBHelper.ExecuteSqlTran(sql);
        }
    }
}