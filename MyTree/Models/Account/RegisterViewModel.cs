﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models.Account
{
	public class RegisterViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "The confirmation password does not match")]
		public string ConfirmPassword { get; set; }

		//[Required]
		//[DataType(DataType.Text)]
		//[Display(Name = "First name")]
		//public string FirstName { get; set; }

		//[Required]
		//[DataType(DataType.Text)]
		//[Display(Name = "Last name")]
		//public string LastName { get; set; }
	}
}
