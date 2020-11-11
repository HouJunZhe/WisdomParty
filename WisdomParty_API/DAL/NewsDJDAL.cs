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
	public class NewsDJDAL
	{
		//��ҳ
		public NewsDJ NewsDJfenye(int page, int size)
		{
			SqlParameter sqlParameter = new SqlParameter("@count", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
			NewsDJ Dj = new NewsDJ();
			SqlParameter[] sqlParameters = new SqlParameter[]
			{
			   new SqlParameter("@page",page),
			   new SqlParameter("@size",size),
			   sqlParameter
			};
			var dt = DBHelper.ExecuteQuery("NewsDJfenye", sqlParameters, System.Data.CommandType.StoredProcedure);
			string str = JsonConvert.SerializeObject(dt);
			List<DJ> z = JsonConvert.DeserializeObject<List<DJ>>(str);
			Dj.dj = z;
			Dj.DJcount = Convert.ToInt32(sqlParameter.Value);
			return Dj;
		}

		//��ӵ�������
		public int NewsDJAdd(DJ j)
		{
			string sql = $"insert into NewsDJ(Djlei,DjTitle,Djmiao,Djimg,DjShiPin,Djnei,DjLY,Djurl) values('{j.Djlei}','{j.DjTitle}','{j.Djmiao}','{j.Djimg}','{j.DjShiPin}','{j.Djnei}','{j.DjLY}','{j.Djurl}')";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//ɾ����������
		public int NewsDJDel(string Id)
		{
			string sql = $"delete from NewsDJ where Djid in ({Id})";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//�޸ĵ�������
		public int NewsDJUpd(DJ j)
		{
			string sql = $"update NewsDJ set Djlei='{j.Djlei}',DjTitle='{j.DjTitle}',Djmiao='{j.Djmiao}',Djimg='{j.Djimg}',DjShiPin='{j.DjShiPin}',Djnei='{j.Djnei}',DjLY='{j.DjLY}',Djurl='{j.Djurl}' where Djid={j.Djid}";
			return DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
		}
		//���������
		public DJ FanNewsDJ(int Id)
		{
			string sql = $"select * from NewsDJ where Djid={Id}";
			var dt = DBHelper.ExecuteQuery(sql, System.Data.CommandType.Text);
			string str = JsonConvert.SerializeObject(dt);
			DJ h = JsonConvert.DeserializeObject<List<DJ>>(str).FirstOrDefault();
			return h;
		}
	}
}