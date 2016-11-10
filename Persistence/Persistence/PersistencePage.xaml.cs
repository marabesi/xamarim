using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Persistence
{
	public partial class PersistencePage : ContentPage
	{

		StudentViewModel svm = new StudentViewModel();

		public PersistencePage()
		{
			BindingContext = svm;

			InitializeComponent();

			studentsListView.ItemsSource = svm.students;

			Content = studentsListView;
		}

		public void OnSelectedItem(object sender, SelectedItemChangedEventArgs args)
		{
			Navigation.PushAsync(new StudentDetail());
		}
	}
}
