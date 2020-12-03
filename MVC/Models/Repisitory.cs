using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using KRcc;

namespace MVC.Models
{
	public class Repisitory
	{
		/// <summary>
		/// 检测机器人状态命令
		/// </summary>
		public string MC_DefaultCheckRobotStatusCommand = ConfigurationManager.AppSettings["CheckRobotStatusCommand"];

		/// <summary>
		/// 检测机器人温度命令
		/// </summary>
		public string MC_DefaultCheckRobotTemperatureCommand = ConfigurationManager.AppSettings["CheckRobotStatusCommand"];

		//public Models.RobotStatus RobotConnect(string ip)
		//{
		//	KRcc.Commu commu = null;

		//	//Models.RobotStatus RobotStatus = new RobotStatus();
			
		//	//机器人默认状态
		//	RobotStatus.Status = Common.Robot.RobotStatus.Default;
			
		//	//连接机器人
		//	commu = RobotOperationHandler.GetCommu(ip, "TCP", "23");
		//	if (RobotOperationHandler.CheckCommu(commu))
		//	{
		//		//解析状态
		//		string commandResult = RobotOperationHandler.RunCommand(commu, MC_DefaultCheckRobotStatusCommand);

		//		//解析温度
		//		//string commandTempResult = RobotOperationHandler.RunCommand(commu, MC_DefaultCheckRobotTemperatureCommand);
		//		//Common.RobotCommandResultAnalysis.AnalysisRobotTemperature(commandTempResult);

		//		//连接状态
		//		RobotStatus.Status = Common.Robot.RobotStatus.Link;
		//	}
		//	else
		//	{
		//		//连接状态
		//		RobotStatus.Status = Common.Robot.RobotStatus.Error;
		//		RobotStatus.RobotIP = ip;
		//	}

		//	return RobotStatus;
		//}
	}
}