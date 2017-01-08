using System;

namespace IotHandler
{
	public class IHerokuService
	{
		public static readonly String USERS_URL = "https://iothandler.herokuapp.com/users?token={0}";
		public static readonly String LOGIN_URL = "https://iothandler.herokuapp.com/login";
	}
}
