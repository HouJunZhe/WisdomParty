using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Users.Dal;
using WisdomParty_API.Models;

namespace WisdomParty_API.DAL
{
    public class DangYuanDAL
    {
        //分页
        public DangYuan DYfenye(int page, int size) 
        {
            DangYuan dy = new DangYuan();
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] sqlParameters = new SqlParameter[] 
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("DYfenye", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<DY> d = JsonConvert.DeserializeObject<List<DY>>(str);
            dy.dy = d;
            dy.DYcount = Convert.ToInt32(sqlParameter.Value);
            return dy;
        }
        //登录党员信息
        public DY DYDeng(DY d) 
        {
            string sql = $"select DYid,DYname from DangYuan where DYhao='{d.DYhao}' and DYpwd='{d.DYpwd}'";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            DY dd = JsonConvert.DeserializeObject<List<DY>>(str).FirstOrDefault();
            return dd;
        }
        //注册党员信息
        public int DYAdd(DY d) 
        {
            string sql = $"insert into DangYuan(DYweixin,DYname,DYhao,DYpwd,DYgonghao,DYsex,DYchusheng,DYxueli,DYrudang,DYzhibu) values('{d.DYweixin}','{d.DYname}','{d.DYhao}','{d.DYpwd}','{d.DYgonghao}','{d.DYsex}','{d.DYchusheng}','{d.DYxueli}','{d.DYrudang}','{d.DYzhibu}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
    }
}