using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KRcc;

namespace MVC
{
	public class RobotOperationHandler
	{
		public static KRcc.Commu GetCommu(string ip)
		{
			return GetCommu(ip, "TCP");
		}

		public static KRcc.Commu GetCommu(string ip, string protocol)
		{
			return GetCommu(ip, protocol, "23");
		}

		public static KRcc.Commu GetCommu(string ip, string protocol, string port)
		{
			try
			{

				return new Commu(string.Format("{0} {1} {2}", protocol, ip, port));
			}
			catch (Exception ex)
			{
				Common.LogHelper.Default.WriteError(string.Format("连接到机器人错误 {0} {1} {2}", protocol, ip, port), ex);
				return null;
			}
		}

		/// <summary>
		/// 检查机器人连接是否已经正常
		/// </summary>
		/// <param name="commu"></param>
		/// <returns></returns>
		public static bool CheckCommu(KRcc.Commu commu)
		{
			return commu != null && commu.IsConnected;
		}

		/// <summary>
		/// 运行命令
		/// </summary>
		/// <param name="commu"></param>
		/// <param name="commandString"></param>
		/// <returns></returns>
		public static string RunCommand(KRcc.Commu commu, string commandString)
		{
			try
			{
				//默认回车
				ArrayList arrayList = commu.command(commandString + "\n");
				int returnStatusCode = 0;
				int.TryParse(arrayList[0].ToString(), out returnStatusCode);

				if (returnStatusCode == 0) return arrayList[1].ToString();

				return string.Empty;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}