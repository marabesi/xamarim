using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MOB.XF.Hello
{
    public partial class NavPage2 : ContentPage
    {
        public NavPage2()
        {
            InitializeComponent();

            Button buttonVoltar = new Button()
            {
                Text = "Voltar",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            buttonVoltar.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };

            this.rootLayout.Children.Add(buttonVoltar);
        }
    }
}
