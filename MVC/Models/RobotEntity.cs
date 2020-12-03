using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MVC.Models
{
	public class RobotEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; }

		[BsonElement("SortNumber")]
		public int SortNumber { get; set; }

		[BsonElement("RobotNumber")]
		public string RobotNumber { get; set; }

		[BsonElement("RobotName")]
		public string RobotName { get; set; }

		[BsonElement("IPAddress")]
		public string IPAddress { get; set; }

		[BsonElement("IsActive")]
		public bool IsActive { get; set; }

		[BsonIgnore]
		public Common.Robot.RobotStatus Status { get; set; }

		[BsonIgnore]
		public Models.RobotStatusEntity RobotStatus { get; set; }

		[BsonIgnore]
		public Models.RobotTemperatureEntity RobotTemperature { get; set; }

	}
}