using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace IotHandler
{
	public class SensorDataAccess
	{
		private SQLiteConnection database;
		private static object collisionLock = new object();
		public ObservableCollection<Sensor> sensors { set; get; }
		private SensorTypeFactory typeSensorFactory = new SensorTypeFactory();


		public SensorDataAccess()
		{
			database = DependencyService.Get<DatabaseConnection>().DbConnection();
			database.CreateTable<Sensor>();
		}

		public ObservableCollection<Sensor> GetSensors()
		{
			lock (collisionLock)
			{
				IEnumerable<Sensor> list = database.Query<Sensor>("SELECT * FROM Sensors").AsEnumerable();

				foreach (var sensor in list) {
					sensor.Type = typeSensorFactory.create(sensor.SensorTypeId);
					sensors.Add(sensor);
				}

				return sensors;
			}
		}

		public int Save(Sensor sensor)
		{
			lock (collisionLock)
			{
				if (sensor.Id != 0)
				{
					database.Update(sensor);
					return sensor.Id;
				}

				database.Insert(sensor);
				return sensor.Id;
			}
		}

		public int DeleteSensor(Sensor sensor)
		{
			var id = sensor.Id;

			if (id != 0)
			{
				lock (collisionLock)
				{
					database.Delete<Sensor>(id);
				}
			}

			App.sensors.Remove(sensor);

			return id;
		}

	}
}

