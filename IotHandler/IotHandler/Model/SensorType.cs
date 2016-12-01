using System;
namespace IotHandler
{
	public class SensorType
	{

		public int Id { set; get; }

		public String Description { set; get; }

		public String Image { set; get; }

		public SensorType () { }

		public SensorType(int Id, String Description, String Image) {
			this.Id = Id;
			this.Description = Description;
			this.Image = Image;
		}
	}
}
