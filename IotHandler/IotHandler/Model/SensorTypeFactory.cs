using System;
using System.Collections.Generic;

namespace IotHandler
{
	public class SensorTypeFactory
	{
		public List<SensorType> sensorList = new List<SensorType>();

		public SensorTypeFactory()
		{
			sensorList.Add(new SensorType(1, "LED", "LED.png"));
			sensorList.Add(new SensorType(2, "DHT11", "DHT11.png"));
			sensorList.Add(new SensorType(3, "DHT22", "DHT22.png"));
			sensorList.Add(new SensorType(4, "Button", "BUTTON.png"));
		}

		public SensorType create(String name = null)
		{
			String wanted = name.ToUpper();

			if (wanted.Equals("LED"))
			{
				return sensorList[0];
			}

			if (wanted.Equals("DHT11"))
			{
				return sensorList[1];
			}

			if (wanted.Equals("DHT22"))
			{
				return sensorList[2];
			}

			if (wanted.Equals("BUTTON"))
			{
				return sensorList[3];
			}

			return new SensorType();
		}

		public SensorType create(int id)
		{ 
			if (id == 1)
			{
				return sensorList[0];
			}

			if (id == 2)
			{
				return sensorList[1];
			}

			if (id == 3)
			{
				return sensorList[2];
			}

			if (id == 4)
			{
				return sensorList[3];
			}

			return new SensorType();
		}
	}
}
