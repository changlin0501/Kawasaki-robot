using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC.Common
{
	public static class RobotCommandResultAnalysis
	{
		/// <summary>
		/// 解析机器状态返回值
		/// </summary>
		/// <param name="commandResult"></param>
		/// <returns></returns>
		public static Models.RobotStatusEntity AnalysisRobotStatus(string commandResult)
		{
			try
			{
				Models.RobotStatusEntity robotStatusEntity = null;

				if (!string.IsNullOrEmpty(commandResult))
				{
					robotStatusEntity = new Models.RobotStatusEntity();

					//自动/手动模式
					string RepeatRegex = @"REPEAT[\u0020|\u3000]+ON";
					robotStatusEntity.REPEAT_Flag = Regex.IsMatch(commandResult, RepeatRegex);

					//重复执行(CycleStart)
					string CSRegex = @"CS[\u0020|\u3000]+ON";
					robotStatusEntity.CS_Flag = Regex.IsMatch(commandResult, CSRegex);

					//马达电源
					string PowerRegex = @"POWER[\u0020|\u3000]+ON";
					robotStatusEntity.POWER_Flag = Regex.IsMatch(commandResult, PowerRegex);

					//紧急急停
					string EmergencyRegex = @"EMERGENCY[\u0020|\u3000]+ON";
					robotStatusEntity.EMERGENCY_Flag = Regex.IsMatch(commandResult, EmergencyRegex);

					//机器人错误
					string ErrorRegex = @"ERROR[\u0020|\u3000]+ON";
					robotStatusEntity.ERROR_Flag = Regex.IsMatch(commandResult, ErrorRegex);
				}

				return robotStatusEntity;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 解析机器人温度
		/// </summary>
		/// <param name="commandResult"></param>
		/// <returns></returns>
		public static Models.RobotTemperatureEntity AnalysisRobotTemperature(string commandResult)
		{
			try
			{
				Models.RobotTemperatureEntity robotTemperatureEntity = null;

				if (!string.IsNullOrEmpty(commandResult))
				{
					robotTemperatureEntity = new Models.RobotTemperatureEntity();

					//取消后面的空格
					commandResult = commandResult.Replace("\r\n\r\n", "");
					//变成行
					string[] allLine = commandResult.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
					//跳过三行
					string[] needLine = allLine.Skip(3).ToArray();

					for (int i = 0; i < needLine.Length; i++)
					{
						string[] parameter = needLine[i].Split("    ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


						switch (parameter[0])
						{
							case "1":
								robotTemperatureEntity.Z1_Temperature = float.Parse(parameter[1]);
								break;
							case "2":
								robotTemperatureEntity.Z2_Temperature = float.Parse(parameter[1]);
								break;
							case "3":
								robotTemperatureEntity.Z3_Temperature = float.Parse(parameter[1]);
								break;
							case "4":
								robotTemperatureEntity.Z4_Temperature = float.Parse(parameter[1]);
								break;
							case "5":
								robotTemperatureEntity.Z5_Temperature = float.Parse(parameter[1]);
								break;
							case "6":
								robotTemperatureEntity.Z6_Temperature = float.Parse(parameter[1]);
								break;
							default:
								break;
						}
					}

				}

				return robotTemperatureEntity;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}