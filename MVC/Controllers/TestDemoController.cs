using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MVC.Controllers
{
    public class TestDemoController : ApiController
    {
		private readonly ClientWebSocket webSocket = new ClientWebSocket();
		private readonly CancellationToken _cancellation = new CancellationToken();

		[HttpPost]
		public async Task SendMsg()
		{
			//连接websocket地址
			await webSocket.ConnectAsync(new Uri("ws://localhost:54032/api/msg"), _cancellation);

			//列表转字节
			List<Models.RobotEntity> RobotData = GetAllRobot();
			JavaScriptSerializer js = new JavaScriptSerializer();
			string data = js.Serialize(RobotData);

			//发送的数据
			var sendBytes = Encoding.UTF8.GetBytes(data);
			var bsend = new ArraySegment<byte>(sendBytes);
			await webSocket.SendAsync(bsend, WebSocketMessageType.Binary, true, _cancellation);
			await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", _cancellation);
			webSocket.Dispose();
		}

		public List<Models.RobotEntity> GetAllRobot()
		{
			List<Models.RobotEntity> RobotList = Models.Test.MC_AllMachineList;
			return RobotList;
		}
	}
}
