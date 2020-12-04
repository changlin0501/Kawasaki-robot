﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi", //name在一个项目中重复
                routeTemplate: "api/{controller}/{action}/{id}",//增加过action
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
