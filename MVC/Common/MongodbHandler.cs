using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC.Common
{
	public class MongodbHandler
	{
		/*默认MongoDB参数*/
		/*-------------------------------------------------------------------------------------*/

		public static string MongodbServiceName = ConfigurationManager.AppSettings["MongodbServiceName"];
		private static string MongodbDefaultUrl = ConfigurationManager.AppSettings["MongodbURL"];
		private static string MongodbDefaultDBName = ConfigurationManager.AppSettings["MongodbName"];

		/// <summary>
		/// 定义一个静态变量来保存类的实例
		/// </summary>
		private static MongodbHandler uniqueInstance;

		/// <summary>
		/// 定义一个标识确保线程同步
		/// </summary>
		private static readonly object locker = new object();


		/*声明变量*/
		/*-------------------------------------------------------------------------------------*/

		/// <summary>
		/// 定义私有构造函数，使外界不能创建该类实例
		/// </summary>
		private MongodbHandler()
		{
			//if (!Common.CommonFunction.ServiceRunning(MongodbServiceName) && Common.ConfigFileHandler.GetAppConfig("CheckMongoDBService") == "1")
			//{
			//	throw new Exception("Mongodb 服务未安装或未运行，无法连接至Mongodb");
			//}

			//client
			mc_MongoClient = new MongoClient(MongodbDefaultUrl);
			//database
			mc_MongoDatabase = mc_MongoClient.GetDatabase(MongodbDefaultDBName);
		}

		/// <summary>
		/// mongo连接客户端
		/// </summary>
		public static MongoClient mc_MongoClient = null;

		/// <summary>
		/// mongo数据库
		/// </summary>
		public IMongoDatabase mc_MongoDatabase = null;

		/// <summary>
		/// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
		/// </summary>
		/// <returns></returns>
		public static MongodbHandler GetInstance()
		{
			// 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
			// 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
			// lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
			// 双重锁定只需要一句判断就可以了
			if (uniqueInstance == null)
			{
				lock (locker)
				{
					// 如果类的实例不存在则创建，否则直接返回
					if (uniqueInstance == null)
					{
						uniqueInstance = new MongodbHandler();
					}
				}
			}
			return uniqueInstance;
		}

		/// <summary>
		/// 找到一条
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
		public IFindFluent<BsonDocument, BsonDocument> Find(IMongoCollection<BsonDocument> collection, FilterDefinition<BsonDocument> filter)
		{
			return collection.Find(filter);
		}

		/*获取数据集合*/
		/*-------------------------------------------------------------------------------------*/

		/// <summary>
		/// 获取数据集
		/// </summary>
		/// <param name="collectionName"></param>
		/// <returns></returns>
		public IMongoCollection<BsonDocument> GetCollection(string collectionName)
		{
			return mc_MongoDatabase.GetCollection<BsonDocument>(collectionName);
		}
	}
}