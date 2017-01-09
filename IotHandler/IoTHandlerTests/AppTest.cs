using NUnit.Framework;
using System;
using IotHandler;
using System.Collections.ObjectModel;

namespace IoTHandlerTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void ShouldCreateEmptyCollectionToHoldAllTheSensors()
		{
			ObservableCollection<Sensor> collection = App.sensors;

			Assert.AreEqual(collection.Count, 0);
		}
	}
}
