using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class Family : Entity
	{
		public string CreatorId { get; set; }
		public List<Person> People { get; set; }

		public Family()
		{
			People = new List<Person>();
		}
	}
}
