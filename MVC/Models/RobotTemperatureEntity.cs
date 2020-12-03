using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
	public class RobotTemperatureEntity
	{
		/// <summary>
		/// 轴1温度
		/// </summary>
		public float Z1_Temperature { get; set; }

		/// <summary>
		/// 轴2温度
		/// </summary>
		public float Z2_Temperature { get; set; }

		/// <summary>
		/// 轴3温度
		/// </summary>
		public float Z3_Temperature { get; set; }

		/// <summary>
		/// 轴4温度
		/// </summary>
		public float Z4_Temperature { get; set; }

		/// <summary>
		/// 轴5温度
		/// </summary>
		public float Z5_Temperature { get; set; }

		/// <summary>
		/// 轴6温度
		/// </summary>
		public float Z6_Temperature { get; set; }
	}
}