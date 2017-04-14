using System;
using System.ComponentModel;
using SQLite;

namespace IotHandler
{
	[Table("Sensors")]
	public class Sensor : INotifyPropertyChanged
	{

		private int _id;

		[PrimaryKey, AutoIncrement]
		public int Id
		{
			set
			{
				this._id = value;
				OnPropertyChanged(nameof(Id));
			}
			get
			{
				return this._id;
			}
		}

		private String _name;

		[NotNull]
		public String Name
		{
			set
			{
				this._name = value;
				OnPropertyChanged(nameof(Name));
			}
			get
			{
				return this._name;
			}
		}

		public String Description { set; get; }

		public String Port { set; get; }

		public int State { set; get; }

		[Ignore]
		public SensorType Type { set; get; }

		private int _sensor_type_id;

		public String Url { set; get; }

		public int Pin { set; get; }

		public String inOut { set; get; }

		[NotNull]
		public int SensorTypeId
		{
			set
			{
				this._sensor_type_id = value;
				OnPropertyChanged(nameof(SensorTypeId));
			}
			get
			{
				return this._sensor_type_id;
			}
		}

		private String _user_id;

		[NotNull]
		public String LoginToken
		{
			set
			{
				this._user_id = value;
				OnPropertyChanged(nameof(LoginToken));
			}
			get
			{
				return this._user_id;
			}
		}

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

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this,
			  new PropertyChangedEventArgs(propertyName));
		}
	}
}
