using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class Pair : Entity
	{
		public bool IsTogether { get; set; }
		public List<PersonPair> Partners { get; set; }
		public List<Person> Children { get; set; }
		public List<Person> AdoptedChildren { get; set; }

		public Pair()
		{
			Partners = new List<PersonPair>();
			Children = new List<Person>();
			AdoptedChildren = new List<Person>();
		}
	}
}
