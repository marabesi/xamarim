using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Persistence
{
	public class Student : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private String _Name;

		public int Id { get; set; }
		public String Name {
			get {
				return _Name;
			}
			set {
				if (_Name == value) {
					return;
				}
				_Name = value;
				OnPropertyChanged("Name");
			} 
		}
		public string RM { get; set; }
		public string Email { get; set; }

		override
		public string ToString()
		{
			return this.Name;
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
