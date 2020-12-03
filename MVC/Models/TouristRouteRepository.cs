using MongoDB.Driver;
using MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
	public class TouristRouteRepository
	{
		/// <summary>
		/// mongo数据库
		/// </summary>
		public IMongoDatabase mc_MongoDatabase = null;

		public Models.RobotEntity GetTouristRoute(string touristRouteId)
		{
		 	var news = new NewsRepository().GetAllStatus().Where((p) => p.id == touristRouteId);
			return null;
			//return mc_MongoDatabase.Tou

			//return _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefault(n => n.Id == touristRouteId);
		}
	}
}