using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models.Profile
{
	public class AddPersonViewModel
	{
		[Required]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Gender")]
		public int Gender { get; set; }

		//[Display(Name = "Add child")]
		//public List<Person> Children { get; set; }

		//[Display(Name = "Add partner")]
		//public Person Partner { get; set; }
	}
}
