using MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MVC.Controllers
{
	public class TestController : ApiController
	{

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
		public List<Models.GetRobotStatus> Status()
		{
			//1.数据库查询
			//var news = new NewsRepository().GetAllStatus();
			MC_AllMachineList = Common.RobotMasterHelper.GetRobotMasterList();

			foreach (var item in MC_AllMachineList)
			{
				KRcc.Commu commu = null;

				commu = RobotOperationHandler.GetCommu(item.IPAddress, "TCP", "23");
				if (RobotOperationHandler.CheckCommu(commu))
				{
					//连接状态
					item.Status = Common.Robot.RobotStatus.Link;
				}
				else
				{
					//错误状态
					item.Status = Robot.RobotStatus.Error;
				}

			}

			
			//连接  
			//MC_RobotStatusTrigger.StartTrigger(2000);

			//List<Models.GetRobotStatus> Output = AutoMapper.Mapper.Map<List<Models.GetRobotStatus>>(MC_AllMachineList);

			//返回

			return null;
		}

		public IHttpActionResult GetProduct(string id)
		{
			var news = new NewsRepository().GetAllStatus().Where((p) => p.id == id);
			if (news == null)
			{
				return NotFound();
			}
			return Ok(news);
		}
	}
}
