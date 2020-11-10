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
    //党建题库
    public class DangJianList
    {
        //分页
        public TK TiKuPage(int page, int size)
        {
            TK tk = new TK();
            SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@page",page),
               new SqlParameter("@size",size),
               sqlParameter
            };
            var dt = DBHelper.ExecuteQuery("DangJianTiKu", sqlParameters, System.Data.CommandType.StoredProcedure);
            string str = JsonConvert.SerializeObject(dt);
            List<TiKu> d = JsonConvert.DeserializeObject<List<TiKu>>(str);
            tk.tk = d;
            tk.TKcount = Convert.ToInt32(sqlParameter.Value);
            return tk;
        }

        //添加题库信息
        public int TiKuAdd(TiKu t)
        {
            string sql = $"insert into TiKu(TKfenlei,TKname,TKleixing,TKxuanxiang,TKqita,TKlaiyuan,TKimg,TKshipin,TKtime) values('{t.TKfenlei}','{t.TKname}','{t.TKleixing}','{t.TKxuanxiang}','{t.TKqita}','{t.TKlaiyuan}','{t.TKimg}','{t.TKshipin}','{t.TKtime}')";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //删除题库信息
        public int TiKuDel(string Id)
        {
            string sql = $"delete from TiKu where TKid in ({Id})";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //修改题库信息
        public int TiKuUpd(TiKu t)
        {
            string sql = $"update TiKu set TKfenlei='{t.TKfenlei}',TKname='{t.TKname}',TKleixing='{t.TKleixing}',TKxuanxiang='{t.TKxuanxiang}',TKqita='{t.TKqita}',TKlaiyuan='{t.TKlaiyuan}',TKimg='{t.TKimg}',TKshipin='{t.TKshipin}',TKtime='{t.TKtime}' where TKid={t.TKid}";
            return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }

        //反填
        public TiKu FanTiKu(int Id)
        {
            string sql = $"select * from TiKu where TKid={Id}";
            var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
            string str = JsonConvert.SerializeObject(dt);
            TiKu t = JsonConvert.DeserializeObject<List<TiKu>>(str).FirstOrDefault();
            return t;
        }
    }
}