using System;
using System.Collections.Generic;

namespace IotHandler.Model.Json
{
	public class SensorData
	{
		public Object Channel { get; set; }

		public List<Feed> Feeds { get; set; }
	}
}
