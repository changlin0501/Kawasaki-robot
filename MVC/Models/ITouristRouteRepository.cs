using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
	public interface ITouristRouteRepository
	{
		//添加api方法 得到所有机器列表
		IEnumerable<Models.RobotEntity> GetRobotRoutes(string keyword);

		//得到特定的机器列表
		Models.RobotEntity GetRobotRoute(string touristRouteId);
	}
}
