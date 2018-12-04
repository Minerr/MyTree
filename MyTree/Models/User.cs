﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class User : Entity
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Person Person { get; set; }
		public List<UserRight> UserRights { get; set; }
	}
}