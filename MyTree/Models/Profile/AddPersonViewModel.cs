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
		[DataType(DataType.Text)]
		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "LastName")]
		public string LastName { get; set; }

		[Required]
		public Gender Gender { get; set; }

		[Display(Name = "Add child")]
		public List<Person> Children { get; set; }

		[Display(Name = "Add partner")]
		public Person Partner { get; set; }
	}
}
