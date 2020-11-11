using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Users.Dal;
using WisdomParty_API.Models;

namespace WisdomParty_API.DAL
{
	public class HDxiangceDAL
	{
		//分页
		public HDxiangce HDxiangcefenye(int page, int size)
		{
			SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
			HDxiangce NHd = new HDxiangce();
			SqlParameter[] sqlParameters = new SqlParameter[]
			{
			   new SqlParameter("@page",page),
			   new SqlParameter("@size",size),
			   sqlParameter
			};
			var dt = DBHelper.ExecuteQuery("HDxiangcefenye", sqlParameters, System.Data.CommandType.StoredProcedure);
			string str = JsonConvert.SerializeObject(dt);
			List<HD> z = JsonConvert.DeserializeObject<List<HD>>(str);
			NHd.hd = z;
			NHd.HDcount = Convert.ToInt32(sqlParameter.Value);
			return NHd;
		}

		//添加活动相册
		public int HDxiangceAdd(HD h)
		{
			string sql = $"insert into HDxiangce(XZname,XZtitle,XZnei,XZimg) values('{h.XZname}','{h.XZtitle}','{h.XZnei}','{h.XZimg}')";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//删除活动相册
		public int HDxiangceDel(string Id)
		{
			string sql = $"delete from HDxiangce where XZid in ({Id})";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//修改活动相册
		public int HDxiangceUpd(HD h)
		{
			string sql = $"update HDxiangce set XZname='{h.XZname}',XZtitle='{h.XZtitle}',XZnei='{h.XZnei}',XZimg='{h.XZimg}' where XZid={h.XZid}";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//反填活动相册
		public HD FanHDxiangce(int Id)
		{
			string sql = $"select * from HDxiangce where XZid={Id}";
			var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
			string str = JsonConvert.SerializeObject(dt);
			HD h = JsonConvert.DeserializeObject<List<HD>>(str).FirstOrDefault();
			return h;
		}
	}
}