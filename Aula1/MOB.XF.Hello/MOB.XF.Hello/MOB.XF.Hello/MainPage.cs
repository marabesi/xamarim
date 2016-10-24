using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MOB.XF.Hello
{
    public class MainPage : ContentPage
    {
        Label labelTexto;

        public MainPage()
        {
            // Tradicional
            //Label label = new Label();
            //label.Text = "Hello ContentPage";
            //this.Content = label;

            labelTexto = new Label() { Text = "Hello ContentPage" };
            var buttonClick = new Button()
            {
                Text = "Clique aqui"
            };
            buttonClick.Clicked += ButtonClick_Clicked;

            // Estilo -> C# 3.0 
            Content = new StackLayout()
            {
                Children =
                    {
                        labelTexto,
                        buttonClick
                    }
            };


            // Condicional para Device - Plataforma
            switch (Device.OS)
            {
                case TargetPlatform.Other:
                    break;
                case TargetPlatform.iOS:
                    break;
                case TargetPlatform.Android:
                    break;
                case TargetPlatform.WinPhone:
                    break;
                case TargetPlatform.Windows:
                    break;
                default:
                    break;
            }

            // Condicional para Device - Aparelho
            switch (Device.Idiom)
            {
                case TargetIdiom.Unsupported:
                    break;
                case TargetIdiom.Phone:
                    break;
                case TargetIdiom.Tablet:
                    break;
                case TargetIdiom.Desktop:
                    break;
                default:
                    break;
            }

            // Padding = new Thickness(20, 40, 20, 20);
            //Padding = Device.OnPlatform(
            //        new Thickness(20, 40, 20, 40),
            //        new Thickness(20, 20, 20, 40),
            //        new Thickness(20, 40, 40, 40)
            //    );

            // Usando expressão Lambda
            Device.OnPlatform(Android: () =>
            {
                Padding = new Thickness(20, 40, 20, 20);
            });
        }

        private void ButtonClick_Clicked(object sender, EventArgs e)
        {
            labelTexto.Text = "Meu primeiro app";
        }
    }
}

