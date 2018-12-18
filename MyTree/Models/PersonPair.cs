using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class PersonPair
	{
		public int PersonId { get; set; }
		public Person Person { get; set; }

		public int PairId { get; set; }
		public Pair Pair { get; set; }
	}
}
