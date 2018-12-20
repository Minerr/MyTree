using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class Person : Entity
	{
		public int FamilyId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Gender Gender { get; set; }
		public List<PersonPair> Relationships { get; set; }

		public Person()
		{
			Relationships = new List<PersonPair>();
		}
	}
}
