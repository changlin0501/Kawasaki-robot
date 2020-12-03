using MVC.Common;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
	public class RobotStatusController : Controller
	{
		//机器列表
		public static List<Models.RobotEntity> MC_AllMachineList = new List<Models.RobotEntity>();

		/// <summary>
		/// 主页
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			Models.RobotEntity MC_ALLRobot = new RobotEntity();
			MC_ALLRobot.IPAddress = "192.168.1.1";

			//var news = new Repisitory().RobotConnect(MC_ALLRobot.IPAddress);
			//返回JSON数据
			//return Json(news, JsonRequestBehavior.AllowGet);
			return View();
		}

		/// <summary>
		/// 单台机器状态
		/// </summary>
		/// <returns></returns>
		public ActionResult GetRobotStatus(int id)
		{
			return View();
		}

		/// <summary>
		/// 查找机器
		/// </summary>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public ActionResult Get(string IPAddress)
		{
			//1.查询数据库中是否存在机器
			MC_AllMachineList = Common.RobotMasterHelper.GetRobotMasterList();


			foreach (var item in MC_AllMachineList)
			{
				IPAddress = item.IPAddress;
				//var news = new Repisitory().RobotConnect(IPAddress);
			}

			return null;
			//return Json(news, JsonRequestBehavior.AllowGet);

			//2.机器状态连接错误





			//3.机器状态循环启动未开启



			//4.正常运行






			//5.异常报警



		}



		public ActionResult GetAll()
		{
			var news = new NewsRepository().GetAllStatus();

			return Json(news, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// 查找指定机器
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>

		public ActionResult GetNewsByID(string ID)
		{
			var news = new NewsRepository().GetAllStatus().Where((p) => p.id == ID);
			return Json(news, JsonRequestBehavior.AllowGet);
		}

	}
}
