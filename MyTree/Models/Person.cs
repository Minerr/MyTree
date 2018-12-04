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
		public string FullName
		{
			get { return FirstName + " " + LastName; }
		}

		public Address Address { get; set; }

		public Person ParentOne { get; set; }
		public Person ParentTwo { get; set; }
		public Person Partner { get; set; }
	}
}
