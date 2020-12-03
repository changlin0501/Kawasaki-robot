using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
	public class RobotStatus
	{
		public string _id { get; set; }

		public string RobotIP { get; set; }

		public string RobotName { get; set; }

		[BsonIgnore]
		public Common.Robot.RobotStatus Status { get; set; }
	}
}