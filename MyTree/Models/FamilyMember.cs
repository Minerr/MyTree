using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class FamilyMember : Entity
	{
		public int FamilyId { get; set; }
		public Person Person { get; set; }
		public Person ParentOne { get; set; }
		public Person ParentTwo { get; set; }
		public Person Partner { get; set; }

	}
}
