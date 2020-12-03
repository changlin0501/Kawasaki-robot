using FluentScheduler;
using MVC.Common;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// 默认机器人个数
		/// </summary>
		public int MC_AllMachineCount = 0;

		/// <summary>
		/// 机器人状态检测触发器
		/// </summary>
		public Common.RobotStatusTrigger MC_RobotStatusTrigger;

		/// <summary>
		/// 机器列表
		/// </summary>
		public List<Models.RobotEntity> MC_AllMachineList = new List<Models.RobotEntity>();

		/// <summary>
		/// 查询数据库
		/// </summary>
		private void SettingDefaultRobotList()
		{
			try
			{
				//读取数据库中的机器列表
				MC_AllMachineList = Common.RobotMasterHelper.GetRobotMasterList();

				//设置完成后，需要设置总数
				MC_AllMachineCount = MC_AllMachineList.Count;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//webapi返回json
			GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

			//设置默认的机器人（最后需要从数据库中取出）
			SettingDefaultRobotList();

			//机器人状态查询触发器
			MC_RobotStatusTrigger = new Common.RobotStatusTrigger(MC_AllMachineList);
			MC_RobotStatusTrigger.StartTrigger();

			AutoMapperConfig.Config();
			//GetMapper();
		}

		public ActionResult GetMapper()
		{
			//实例化实体List
			//List<StudentEntity> StudentList = new List<StudentEntity>();
			List<Models.RobotEntity> StudentList = new List<Models.RobotEntity>();
			StudentList = Common.RobotMasterHelper.GetRobotMasterList();


			//模拟数据
			//StudentList.Add(new Models.RobotEntity
			//{
			//	//Id = 1,
			//	//Age = 12,
			//	//Gander = "boy",
			//	//Name = "WangZeLing",
			//	//Say = "Only the paranoid survive",
			//	//Score = 99M

			//	   id ="5f680ef2ca11544b68fe84db"),
			//		SortNumber = 1,
			//		RobotNumber="01",
			//		RobotName="RS01N0001",
			//		IPAddress: "192.168.0.2",
			//});
			//AuotMapper具体使用方法 将List<StudentOutput>转换为List<StudentOutput>
			List<Models.GetRobotStatus> Output = AutoMapper.Mapper.Map<List<Models.GetRobotStatus>>(StudentList);
			//return Json(Output, JsonRequestBehavior.AllowGet);
			return null;
		}

	}
}
