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
    /// Lógica interna para TelaRelatorio.xaml
    /// </summary>
    public partial class TelaRelatorio : Window
    {
        Controle controle = new Controle();
        public TelaRelatorio()
        {
            InitializeComponent();       
        }

        private void BotaoAbrirMenu_Relatorio_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaInicial();
            this.Close();
        }

        private void BotaoAbrirQuestionario_Relatorio_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaQuestionario();
            this.Close();
        }

        private void BotaoAbrirRelatorio_Relatorio_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
