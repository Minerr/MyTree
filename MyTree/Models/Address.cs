using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public class Address : Entity
	{
		public string Street { get; set; }
		public string City { get; set; }
		public int ZipCode { get; set; }
		public string Country { get; set; }
	}
}
