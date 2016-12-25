using NUnit.Framework;
using System;
using IotHandler;

namespace IoTHandlerTests
{
	[TestFixture()]
	public class SensorTypeFactoryTest
	{
		private SensorTypeFactory factory;

		[SetUp()]
		public void SetUp()
		{
			factory = new SensorTypeFactory();
		}

		[TearDown()]
		public void TearDown()
		{
			factory = null;
		}

		[Test()]
		public void shouldBuildAledSensor()
		{
			SensorType led = factory.create("led");

			Assert.AreEqual(led.Description, "LED");
		}

		[Test()]
		public void shouldBuildAdht11Sensor()
		{
			SensorType led = factory.create("dht11");

			Assert.AreEqual(led.Description, "DHT11");
		}

		[Test()]
		public void shouldBuildAdht22Sensor()
		{
			SensorType led = factory.create("dht22");

			Assert.AreEqual(led.Description, "DHT22");
		}

		[Test()]
		public void shouldBuildAbuttonSensor()
		{
			SensorType led = factory.create("button");

			Assert.AreEqual(led.Description, "Button");
		}
	}
}