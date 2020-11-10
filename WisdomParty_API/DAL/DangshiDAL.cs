using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.Dal;
using WisdomParty_API.Models;

namespace WisdomParty_API.DAL
{
	public class DangshiDAL
	{
		//分页
		public Dangshi Dangshifenye(int page, int size)
		{
			SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
			Dangshi Nds = new Dangshi();
			SqlParameter[] sqlParameters = new SqlParameter[]
			{
			   new SqlParameter("@page",page),
			   new SqlParameter("@size",size),
			   sqlParameter
			};
			var dt = DBHelper.ExecuteQuery("Dangshifenye", sqlParameters, System.Data.CommandType.StoredProcedure);
			string str = JsonConvert.SerializeObject(dt);
			List<DS> z = JsonConvert.DeserializeObject<List<DS>>(str);
			Nds.ds = z;
			Nds.DScount = Convert.ToInt32(sqlParameter.Value);
			return Nds;
		}

		//添加党史人物
		public int DangshiAdd(DS d)
		{
			string sql = $"insert into Dangshi(Dslei,DsTitle,Dsmiao,Dsimg,DsShiPin,Dsnei,DsjLY,Dsurl) values('{d.Dslei}','{d.DsTitle}','{d.Dsmiao}','{d.Dsimg}','{d.DsShiPin}','{d.Dsnei}','{d.DsjLY}','{d.Dsurl}')";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//删除党史人物
		public int DangshiDel(string Id)
		{
			string sql = $"delete from Dangshi where Dsid in ({Id})";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//修改党史人物
		public int DangshiUpd(DS d)
		{
			string sql = $"update Dangshi set Dslei='{d.Dslei}',DsTitle='{d.DsTitle}',Dsmiao='{d.Dsmiao}',Dsimg='{d.Dsimg}',DsShiPin='{d.DsShiPin}',Dsnei='{d.Dsnei}',DsjLY='{d.DsjLY}',Dsurl='{d.Dsurl}' where Dsid={d.Dsid}";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//反填党史人物
		public DS FanDangshi(int Id)
		{
			string sql = $"select * from Dangshi where Dsid={Id}";
			var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
			string str = JsonConvert.SerializeObject(dt);
			DS d = JsonConvert.DeserializeObject<List<DS>>(str).FirstOrDefault();
			return d;
		}
	}
}