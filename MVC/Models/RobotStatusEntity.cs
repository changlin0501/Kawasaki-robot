using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
	public class RobotStatusEntity
	{
		/// <summary>
		/// 马达电源
		/// </summary>
		public bool POWER_Flag { get; set; }

		/// <summary>
		/// 自动/手动模式
		/// </summary>
		public bool REPEAT_Flag { get; set; }

		/// <summary>
		/// 生命周期
		/// </summary>
		public bool CS_Flag { get; set; }

		/// <summary>
		/// 紧急急停
		/// </summary>
		public bool EMERGENCY_Flag { get; set; }

		/// <summary>
		/// 机器人错误
		/// </summary>
		public bool ERROR_Flag { get; set; }


		/// <summary>
		/// 机器人程序错误
		/// </summary>
		public bool ProgramError_Flag { get; set; }
	}
}