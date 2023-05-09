using System;
namespace eaidyAPI.Entities.Models
{
	public class ResponseModel
	{
		public int status { get; set; }

		public Object? payload { get; set; }

		public string message { get; set; }
	}
}

