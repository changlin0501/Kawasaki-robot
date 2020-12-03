using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
	public interface RobotRepository
	{
		IEnumerable<Models.RobotEntity> GetAll()

		RobotEntity Get(int id);

		RobotEntity Add(RobotEntity item);

		void Remove(int id);

		bool Update(RobotEntity item);
	}
}
