using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NCIProject.Models
{
	public class UserAccount
	{
		[Required(ErrorMessage = "Please enter a User_ID.")]
		public int User_ID { set; get; }

		[Required(ErrorMessage = "Please enter student_ID.")]
		public Student_ID Student_ID { set; get; }

		[Required(ErrorMessage = "Please enter Username.")]
		public string Username { set; get; }

		[Required(ErrorMessage = "Please enter Password.")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
		public string Password { set; get; }

		[NotMapped]
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Please enter Email.")]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
		public string Email { set; get; }
		public string SecurityStamp { set; get; }
	}

	public enum Student_ID
	{
		Admin,
		User
	}
}