using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
	public class GetRobotStatus
	{

		[BsonElement("RobotNumber")]
		public int RobotNumber { get; set; }

		[BsonElement("IPAddress")]
		public string IPAddress { get; set; }

		[BsonElement("RobotName")]
		public string RobotName { get; set; }

		[BsonIgnore]
		public Common.Robot.RobotStatus Status { get; set; }
	}
}