using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MOB.XF.Hello
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void TxtAluno_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.mensagemStatus.Text = string.Empty;
        }

        private void OnButtton_Cadastrar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtAluno.Text))
            {
                this.mensagemStatus.Text = "Informe o nome do aluno.";
            }
            else
            {
                this.txtAluno.Text = string.Empty;
                this.mensagemStatus.Text = "Cadastrado com sucesso.";
            }
        }
    }
}
