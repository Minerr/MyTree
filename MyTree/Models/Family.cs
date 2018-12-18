using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class Family : Entity
	{
		public List<Person> People { get; set; }
	}
}
