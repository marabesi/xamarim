using System;
namespace IotHandler
{
	public class Sensor
	{
		public String Name { set; get; }
		public String Description { set; get; }
		public String Port { set; get; }
		public int State { set; get; }
		public SensorType Type { set; get; }

		public Sensor()
		{
		}

		public Sensor(String Name, String Description, String Port, int State, SensorType Type)
		{
			this.Name = Name;
			this.Description = Description;
			this.Port = Port;
			this.State = State;
			this.Type = Type;
		}

		public override String ToString()
		{
			return this.Name;
		}		
	}
}
