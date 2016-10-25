using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MVVM
{
    public partial class StudentViewPage : ContentPage
    {
        StudentViewModel studentViewModel;

        public StudentViewPage()
        {
            var student = StudentViewModel.GetStudent();
            studentViewModel = new StudentViewModel(student);
            BindingContext = studentViewModel;

            InitializeComponent();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var selectedStudent = args.Item as Student;
            DisplayAlert("Selected studet", string.Format("{0}", selectedStudent.Id), "OK");
        }
    }
}
