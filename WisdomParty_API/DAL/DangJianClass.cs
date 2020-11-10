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
    //党建会议（三会一课）
    public class DangJianClass
    {
        //分页
        public SH SHPage(int page, int size)
        {
            SH sh = new SH();
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("SanHuifenye", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<SanHui> d = JsonConvert.DeserializeObject<List<SanHui>>(str);
            sh.sh = d;
            sh.SHcount = Convert.ToInt32(sqlParameter.Value);
            return sh;
        }

        //添加三会一课信息
        public int JiaoYuAdd(SanHui s)
        {
            string sql = $"insert into SanHui(Shlei,ShTitle,HuiYish,ShKtime,ShJtime,FuJian,ShZt) values('{s.Shlei}','{s.ShTitle}','{s.HuiYish}','{s.ShKtime}','{s.ShJtime}','{s.FuJian}','{s.ShZt}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //删除三会一课信息
        public int SanHuiDel(string Id)
        {
            string sql = $"delete from SanHui where Shid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //修改三会一课信息
        public int SanHuiUpd(SanHui s)
        {
            string sql = $"update SanHui set Shlei='{s.Shlei}',ShTitle='{s.ShTitle}',HuiYish='{s.HuiYish}',ShKtime='{s.ShKtime}',ShJtime='{s.ShJtime}',FuJian='{s.FuJian}',ShZt='{s.ShZt}' where Shid={s.Shid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //反填
        public SanHui FanSanHui(int Id)
        {
            string sql = $"select * from SanHui where Shid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            SanHui s = JsonConvert.DeserializeObject<List<SanHui>>(str).FirstOrDefault();
            return s;
        }
    }
}