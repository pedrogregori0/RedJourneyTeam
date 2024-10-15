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

namespace WPF_API_PIM_IV.view
{
    /// <summary>
    /// Lógica interna para TelaObra3.xaml
    /// </summary>
    public partial class TelaObra3 : Window
    {
        Controle controle = new Controle();

        public TelaObra3()
        {
            InitializeComponent();
        }

        private void BotaoVoltarObra3_Click(object sender, RoutedEventArgs e)
        {
            controle.Navegar(3, false);
            this.Close();
        }

        private void BotaoProximoObra3_Click(object sender, RoutedEventArgs e)
        {
            controle.Navegar(3, true); 
            this.Close();
        }

        private void BotaoAbrirMenu_Obra3_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaInicial();
            this.Close();
        }

        private void BotaoAbrirQuestionario_Obra3_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaQuestionario();
            this.Close();
        }

        private void BotaoAbrirRelatorio_Obra3_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaRelatorio();
            this.Close();
        }
    }
}
