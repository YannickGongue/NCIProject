using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCIProject
{
	public class clSetting
	{
		public static string connectionString()
		{
			string strConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                   Initial Catalog=DbProjectSub;Integrated Security=True";
			return strConnectionString;
		}
	}
}