using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class FamilyMember : Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Address Address { get; set; }
		public FamilyMember ParentOne { get; set; }
		public FamilyMember ParentTwo { get; set; }
		public FamilyMember Partner { get; set; }
	}
}
