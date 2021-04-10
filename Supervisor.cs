using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCIProject.Models
{
	public class Supervisor
	{
		public int Supervisor_ID { set; get; }
		public string Firstname { set; get; }
		public string Lastname { set; get; }		
		public int Email { set; get; }
	}
}