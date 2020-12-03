using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Common
{
	public class NewsRepository
	{
		//机器列表
		public static List<Models.RobotEntity> MC_AllMachineList = new List<Models.RobotEntity>();

		public IEnumerable<Models.RobotEntity> GetAllStatus()
		{
			MC_AllMachineList = Common.RobotMasterHelper.GetRobotMasterList();
			return MC_AllMachineList;
		}
	}
}