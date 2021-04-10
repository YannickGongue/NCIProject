using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCIProject.Models
{
	public class StudentModel 
	{
		public int Matrikelnummer { set; get; }
		public string Firstname { set; get; }
		public string Lastname { set; get; }
		public string Email { set; get; }
		public int Course_ID { set; get; }
		public int Stream_ID { set; get; }
		public int Supervisor_ID { set; get; }		
	}	
}