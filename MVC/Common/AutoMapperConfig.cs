using AutoMapper;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Common
{
	public class AutoMapperConfig
	{
		public static void Config()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Models.RobotEntity, Models.GetRobotStatus>();
			});
		}

		public class MapperProfile : Profile
		{
			public MapperProfile()
			{
				CreateMap<Models.RobotEntity, Models.GetRobotStatus>();
			}
		}
		
	}
}