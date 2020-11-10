using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WisdomParty_API.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Users.Dal;

namespace WisdomParty_API.DAL
{
    //党建学习
    public class DangJianLearning
    {
        //分页
        public JY JYPage(int page, int size)
        {
            JY jy = new JY();
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("DangJianLearn", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<JiaoYu> d = JsonConvert.DeserializeObject<List<JiaoYu>>(str);
            jy.jy = d;
            jy.JYcount = Convert.ToInt32(sqlParameter.Value);
            return jy;
        }

        //添加教育信息
        public int JiaoYuAdd(JiaoYu j)
        {
            string sql = $"insert into JiaoYu(JYlei,JYTitle,JYmiao,JYFaBuRiQi,JYimg,JYShiPin,JYnei,JYjLY,JYurl) values('{j.JYlei}','{j.JYTitle}','{j.JYmiao}','{j.JYFaBuRiQi}','{j.JYimg}','{j.JYShiPin}','{j.JYnei}'.'{j.JYjLY}','{j.JYurl}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //删除教育信息
        public int JiaoYuDel(string Id)
        {
            string sql = $"delete from JiaoYu where JYid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //修改教育信息
        public int NewsUpd(JiaoYu j)
        {
            string sql = $"update JiaoYu set JYlei='{j.JYlei}',JYTitle='{j.JYTitle}',JYmiao='{j.JYmiao}',JYFaBuRiQi='{j.JYFaBuRiQi}',JYimg='{j.JYimg}',JYShiPin='{j.JYShiPin}',JYnei='{j.JYnei}'.JYjLY='{j.JYjLY}',JYurl='{j.JYurl}' where JYid={j.JYid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //反填
        public JiaoYu FanJiaoYu(int Id)
        {
            string sql = $"select * from JiaoYu where JYid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            JiaoYu j = JsonConvert.DeserializeObject<List<JiaoYu>>(str).FirstOrDefault();
            return j;
        }
    }
}