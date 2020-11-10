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
    //政策法规
    public class ZhengGeDAL
    {
        //分页
        public ZhengGe NewsZXfenye(int page, int size)
        {
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            ZhengGe Zhg = new ZhengGe();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("ZhengGefenye", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<ZG> z = JsonConvert.DeserializeObject<List<ZG>>(str);
            Zhg.zg = z;
            Zhg.ZGcount = Convert.ToInt32(sqlParameter.Value);
            return Zhg;
        }
        //添加
        public int ZGAdd(ZG z) 
        {
            string sql = $"insert into ZhengGe(ZGlei,ZGTitle,ZGmiao,ZGimg,ZGShiPin,ZGnei,ZGjLY,ZGurl) values('{z.ZGlei}','{z.ZGTitle}','{z.ZGmiao}','{z.ZGimg}','{z.ZGShiPin}','{z.ZGnei}','{z.ZGjLY}','{z.ZGlei}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //删除
        public int ZGDel(string Id)
        {
            string sql = $"delete from ZhengGe where ZGid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql,System.Data.CommandType.Text);
        }
        //修改
        public int ZGUpd(ZG z) 
        {
            string sql = $"Update ZhengGe set ZGlei='{z.ZGlei}',ZGTitle='{z.ZGTitle}',ZGmiao='{z.ZGmiao}',ZGimg='{z.ZGimg}',ZGShiPin='{z.ZGShiPin}',ZGnei='{z.ZGnei}',ZGjLY='{z.ZGjLY}',ZGurl='{z.ZGurl}' where ZGid={z.ZGid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填
        public ZG FanNewsZX(int Id)
        {
            string sql = $"select * from ZhengGe where ZGid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            ZG z = JsonConvert.DeserializeObject<List<ZG>>(str).FirstOrDefault();
            return z;
        }
    }
}