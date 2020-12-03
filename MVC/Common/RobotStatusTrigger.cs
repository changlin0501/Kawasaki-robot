using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using KRcc;

namespace MVC.Common
{
	public class RobotStatusTrigger
	{
		List<Thread> threads = new List<Thread>();

		/// <summary>
		/// 实例化
		/// </summary>
		/// <param name="robotEntities"></param>
		public RobotStatusTrigger(List<Models.RobotEntity> robotEntities)
		{
			if (string.IsNullOrEmpty(MC_DefaultCheckRobotStatusCommand)) throw new Exception("未知检测机器人状态命令[SWITCH ???]！");

			this.MC_AllMachineList = robotEntities;
		}

		//机器列表
		public List<Models.RobotEntity> MC_AllMachineList;

		/// <summary>
		/// 检测机器人状态命令
		/// </summary>
		public string MC_DefaultCheckRobotStatusCommand = ConfigurationManager.AppSettings["CheckRobotStatusCommand"];

		/// <summary>
		/// 检测机器人温度命令
		/// </summary>
		public string MC_DefaultCheckRobotTemperatureCommand = ConfigurationManager.AppSettings["CheckRobotStatusCommand"];

		/// <summary>
		/// 检测机器人状态间隔时间（毫秒）
		/// </summary>
		public int MC_DefaultCheckRobotStatusIntervalMilliseconds = int.Parse(ConfigurationManager.AppSettings["CheckRobotStatusIntervalMilliseconds"]);


		/// <summary>
		/// 开始监控
		/// </summary>
		/// <returns></returns>
		public bool StartTrigger()
		{
			Random rd = new Random();
			int RandomNumber = rd.Next(1000, 2000);
			return StartTrigger(MC_DefaultCheckRobotStatusIntervalMilliseconds + RandomNumber);
		}

		/// <summary>
		/// 开始监控(设定时间)
		/// </summary>
		/// <param name="IntervalMilliseconds"></param>
		/// <returns></returns>
		public bool StartTrigger(int IntervalMilliseconds)
		{
			try
			{
				foreach (var item in MC_AllMachineList)
				{
					string robotID = item.id;

					var t = new Thread(new ThreadStart(() =>
					{

						//一直运行
						while (true)
						{
							Thread.Sleep(IntervalMilliseconds);

							KRcc.Commu commu = null;
							try
							{
								//默认状态
								item.Status = Common.Robot.RobotStatus.Default;

								//连接机器人
								commu = RobotOperationHandler.GetCommu(item.IPAddress, "TCP", "23");
								if (RobotOperationHandler.CheckCommu(commu))
								{
									//解析状态
									string commandResult = RobotOperationHandler.RunCommand(commu, MC_DefaultCheckRobotStatusCommand);
									item.RobotStatus = Common.RobotCommandResultAnalysis.AnalysisRobotStatus(commandResult);

									//解析温度
									//string commandTempResult = RobotOperationHandler.RunCommand(commu, MC_DefaultCheckRobotTemperatureCommand);
									//item.RobotTemperature = Common.RobotCommandResultAnalysis.AnalysisRobotTemperature(commandTempResult);

									//连接状态
									item.Status = Common.Robot.RobotStatus.Link;
								}
							}
							catch (Exception)
							{
								//错误状态
								item.Status = Robot.RobotStatus.Error;
								throw;

							}
							finally
							{
								if (RobotOperationHandler.CheckCommu(commu))
								{
									commu.disconnect();

								}
								//清除变量
								if (commu != null) commu.Dispose();
							}

						}
					}));
					t.Name = robotID;
					t.Start();

					threads.Add(t);
				}
				return true;
			}
			catch (Exception ex)
			{
				//Common.LogHandler.WriteLog("机器人状态错误 原因是：" + ex.Message, ex);
				throw ex;
			}
		}

	}
}