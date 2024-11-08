using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; 
using System.Windows.Shapes;
using WPF_API_PIM_IV.Controller;


namespace WPF_API_PIM_IV
{
    /// <summary>
    /// Lógica interna para TelaTeclado.xaml
    /// </summary>
    public partial class TelaTeclado : Window
    {

        private TelaQuestionario telaQuestionario = new TelaQuestionario();
        private Controle controle = new Controle();
        private TextBox textBoxSelecionada;
        

        public TelaTeclado(TelaQuestionario questionario)
        {
            InitializeComponent();
            this.telaQuestionario = questionario;

            var telaAltura = SystemParameters.PrimaryScreenWidth;
            var telaLargura = SystemParameters.PrimaryScreenHeight;

            this.Left = (telaAltura - this.Width) / 2;
            this.Top = telaLargura - this.Height;
        }


        private void BotaoTeclado_Click(object sender, RoutedEventArgs e)
        {
            textBoxSelecionada = telaQuestionario.textboxSelecionado;

            // continuar fazendo o metodo do click que vai ser colocado em todos click de botão
            if (textBoxSelecionada != null)
            {
                Button botaoClicado = sender as Button;
                string textoTecla = botaoClicado.Content.ToString();
                textBoxSelecionada.Text += textoTecla;
                textBoxSelecionada.CaretIndex = textBoxSelecionada.Text.Length;

            }
        }

        private void BotaoTecladoDelete (object sender, RoutedEventArgs e)
        {
            if (textBoxSelecionada != null && textBoxSelecionada.Text.Length > 0) 
            { 
                textBoxSelecionada.Text = textBoxSelecionada.Text.Substring(0, textBoxSelecionada.Text.Length - 1);
                textBoxSelecionada.CaretIndex = textBoxSelecionada.Text.Length;
            }
        }

        private void BotaoTecladoEspaco (object sender, RoutedEventArgs e)
        {
            if(textBoxSelecionada != null)
            {
                textBoxSelecionada.Text += " ";
                textBoxSelecionada.CaretIndex = textBoxSelecionada.Text.Length;
            }
        }

        private void BotaoTecladoEnter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        

    }
}
