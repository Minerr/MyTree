using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTree.Models
{
	public enum UserRole
	{
		FullUser,	// All functionality, only one to give access.
		PartUser,	// A User who where given access.
		Player		// A User who can play the game and has statistics
	}
}
