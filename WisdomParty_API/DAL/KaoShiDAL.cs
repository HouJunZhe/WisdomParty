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
    //在线考试
    public class KaoShiDAL
    {
        //分页
        public KaoShi NewsZXfenye(int page, int size)
        {
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            KaoShi kao = new KaoShi();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("NnewZYfenye", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<KS> z = JsonConvert.DeserializeObject<List<KS>>(str);
            kao.ks = z;
            kao.KScount = Convert.ToInt32(sqlParameter.Value);
            return kao;
        }

        //添加
        public int KSAdd(KS k) 
        {
            string sql = $"insert into KaoShi values('{k.KSname}','{k.KSkaishi}','{k.KSjiezhi}','{k.KSshuoming}','{k.DTtime}','{k.TMNum}','{k.XZtimu}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //删除
        public int LBdel(string Id)
        {
            string sql = $"delete from KaoShi where KSid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填
        public KS FanLB(int Id)
        {
            string sql = $"select * from KaoShi where KSid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            KS z = JsonConvert.DeserializeObject<List<KS>>(str).FirstOrDefault();
            return z;
        }
        //修改
        public int KSupd(KS k) 
        {
            string sql = $"update KaoShi set KSname='{k.KSname}',KSkaishi='{k.KSkaishi}',KSjiezhi='{k.KSjiezhi}',KSshuoming='{k.KSshuoming}',DTtime='{k.DTtime}',TMNum='{k.TMNum}',XZtimu='{k.XZtimu}' where KSid={k.KSid}";
            return DBHelper.ExecuteNonQuery(sql,System.Data.CommandType.Text);
        }
    }
}