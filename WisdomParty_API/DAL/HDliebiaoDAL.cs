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
    //活动列表
    public class HDliebiaoDAL
    {
        //分页
        public HDliebiao NewsZXfenye(int page, int size)
        {
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            HDliebiao hd = new HDliebiao();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("NnewZYfenye", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<LB> z = JsonConvert.DeserializeObject<List<LB>>(str);
            hd.lb = z;
            hd.LBcount = Convert.ToInt32(sqlParameter.Value);
            return hd;
        }
        //添加
        public int LBAdd(LB l) 
        {
            string sql = $"insert into HDliebiao(HDtitle,HDdizhi,HDkaishi,HDjieshu,HDjiezhi,HDZt,HDimg,HDnei) values('{l.HDtitle}','{l.HDdizhi}','{l.HDkaishi}','{l.HDjieshu}','{l.HDjiezhi}','{l.HDZt}','{l.HDimg}','{l.HDnei}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //删除
        public int LBdel (string Id)
        {
            string sql = $"delete from HDliebiao where HDlbid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //修改
        public int LBUpd(LB l) 
        {
            string sql = $"update HDliebiao set HDtitle='{l.HDtitle}',HDdizhi='{l.HDdizhi}',HDkaishi='{l.HDkaishi}',HDjieshu='{l.HDjieshu}',HDjiezhi='{l.HDjiezhi}',HDZt='{l.HDZt}',HDimg='{l.HDimg}',HDnei='{l.HDnei}' where HDlbid={l.HDlbid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填
        public LB FanLB(int Id)
        {
            string sql = $"select * from HDliebiao where HDlbid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            LB z = JsonConvert.DeserializeObject<List<LB>>(str).FirstOrDefault();
            return z;
        }
    }
}