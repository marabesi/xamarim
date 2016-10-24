using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MOB.XF.Hello
{
    public partial class NavHomePage : ContentPage
    {
        public NavHomePage()
        {
            InitializeComponent();
        }

        public void OnButtonClick(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NavPage2());
        }
    }
}
