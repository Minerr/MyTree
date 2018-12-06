using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class Person : Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Address Address { get; set; }
		public DateTime Birthday { get; set; }
	}
}
