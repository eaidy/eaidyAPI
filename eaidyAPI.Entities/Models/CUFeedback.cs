using System;
using eaidyAPI.Entities;

namespace eaidyAPI.Entities.Models
{
	public class CUFeedback
	{
		public User? user { get; set; }

		public CCFeedback feedback { get; set; }
	}
}

