using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public enum Functionality
	{
		EditFamilyTree,
		ShowStatistics,
		GiveAccess,
		PlayGame
	}

	public class UserRight : Entity
	{
		public Functionality Functionality { get; set; }
	}
}
