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
    public class NewsZXDAL
    {
        //分页
        public NewsZX NewsZXfenye(int page, int size) 
        {
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            NewsZX Nzx = new NewsZX();
            SqlParameter[] sqlParameters = new SqlParameter[] 
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("NnewZYfenye", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<ZX> z = JsonConvert.DeserializeObject<List<ZX>>(str);
            Nzx.zx = z;
            Nzx.ZXcount = Convert.ToInt32(sqlParameter.Value);
            return Nzx;
        }
        //添加新闻资讯
        public int NewsZXAdd(ZX n) 
        {
            string sql = $"insert into NewsZX(Nzxlei,NzxTitle,Nzmiao,Nzimg,NzShiPin,Nznei,NzxLY,Nzurl) values('{n.Nzxlei}','{n.NzxTitle}','{n.Nzmiao}','{n.Nzimg}','{n.NzShiPin}','{n.Nznei}','{n.NzxLY}','{n.Nzurl}')";
            return DBHelper.ExecuteNonQuery(sql,System.Data.CommandType.Text);
        }
        //删除新闻资讯
        public int NewsZXDel(string Id) 
        {
            string sql = $"delete from NewsZX where Nzxid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //修改新闻资讯
        public int NewsUpd(ZX z) 
        {
            string sql = $"update NewsZX set Nzxlei='{z.Nzxlei}',NzxTitle='{z.NzxTitle}',Nzmiao='{z.Nzmiao}',Nzimg='{z.Nzimg}',NzShiPin='{z.NzShiPin}',Nznei='{z.Nznei}',NzxLY='{z.NzxLY}',Nzurl='{z.Nzurl}' where Nzxid={z.Nzxid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }
        //反填
        public ZX FanNewsZX(int Id) 
        {
            string sql = $"select * from NewsZX where Nzxid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            ZX z = JsonConvert.DeserializeObject<List<ZX>>(str).FirstOrDefault();
            return z;
        } 
    }
}