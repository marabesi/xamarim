using System;

namespace IotHandler
{
	public class IHerokuService
	{
		readonly static String TOKEN = "123456";

		public static readonly String USERS_URL = string.Format("https://iothandler.herokuapp.com/users?token={0}", TOKEN);
	}
}
