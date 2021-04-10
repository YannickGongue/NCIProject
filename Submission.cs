using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCIProject.Models
{
	public class Submission 
	{
		public int Submission_ID { set; get; }
		public Student Student_ID { set; get; }
		public HttpPostedFileBase File_ID { set; get; }
		public string Linkedlin { set; get; }
		public string Projektfile { set; get; }
		public string Shortdesc { set; get; }
		public string Longdesc { set; get; }   
		public string Tech { set; get; }
	}

	public enum Student
	{
		Admin,
		User
	}
}