using MVC.Common;
using MVC.Models;
using System;using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MVC.Controllers
{
	public class TestController : ApiController
	{
		public List<Models.RobotEntity> newMachintAll;

		/// <summary>
		/// 机器人状态检测触发器
		/// </summary>
		public Common.RobotStatusTrigger MC_RobotStatusTrigger;

		/// <summary>
		/// 机器列表
		/// </summary>
		public List<Models.RobotEntity> MC_AllMachineList = new List<Models.RobotEntity>();

		[HttpGet]
		[Route(template: "api/Test/Status")]
		public string Status()
		{
			//1.数据库查询
			//var news = new NewsRepository().GetAllStatus();
			//MC_AllMachineList = Common.RobotMasterHelper.GetRobotMasterList();

			return null;

			//List<Models.GetRobotStatus> Output = AutoMapper.Mapper.Map<List<Models.GetRobotStatus>>(MC_AllMachineList);
		}

		//public IHttpActionResult GetProduct(string id)
		//{
		//	var news = new NewsRepository().GetAllStatus().Where((p) => p.id == id);
		//	if (news == null)
		//	{
		//		return NotFound();
		//	}
		//	return Ok(news);
		//}

		public List<Models.RobotEntity> GetAllRobot()
		{
			List<Models.RobotEntity> RobotList = Models.Test.MC_AllMachineList;
			return RobotList;
		}
	}
}

