using System;
using SQLite;

namespace IotHandler
{
	[Table("User")]
	public class User
	{
		public String _Id { set; get; }

		public String Name { set; get; }

		public String Email { set; get; }

		public String Password { set; get; }

		public String Token { set; get; }

		public User()
		{
		}

		public User(String Id, String Name, String Email, String Password, String Token)
		{
			this._Id = Id;
			this.Name = Name;
			this.Email = Email;
			this.Password = Password;
			this.Token = Token;
		}
	}
}
