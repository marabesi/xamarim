using MOB.XF.Hello.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MOB.XF.Hello
{
    public partial class AlunoViewPage : ContentPage
    {
        public AlunoViewPage()
        {
            Aluno aluno = GetAluno("Maria Silva", "15425", "maria@fiap.com.br");
            BindingContext = aluno;

            InitializeComponent();
        }

        /// <summary>
        /// Recupera o usuário por meio de um web serivce
        /// </summary>
        /// <param name="nome">Infomar o nome do aluno</param>
        /// <param name="rm">Informar o rm do aluno</param>
        /// <param name="email">Informar o email do aluno</param>
        /// <returns>Esse método retorna o aluno instanciado</returns>
        private Aluno GetAluno(string nome, string rm, string email)
        {
            return new Aluno()
            {
                Nome = nome,
                RM = rm,
                Email = email
            };
        }
    }
}
