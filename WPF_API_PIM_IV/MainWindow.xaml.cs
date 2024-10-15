using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_API_PIM_IV.Controller;
using WPF_API_PIM_IV.view;
namespace WPF_API_PIM_IV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controle controle = new Controle();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BotaoHomeAbrirObra1_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaObra1();
            this.Close();    
        }

        private void BotaoHomeAbrirObra2_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaObra2();
            this.Close();
        }

        private void BotaoHomeAbrirObra3_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaObra3();
            this.Close();
        }

        private void BotaoHomeAbrirObra4_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaObra4();
            this.Close();
        }

        private void BotaoHomeAbrirObra5_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaObra5();
            this.Close();
        }

        private void BotaoHomeAbrirObra6_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaObra6();
            this.Close();
        }

        private void BotaoAbrirQuestionario_Home_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaQuestionario();
            this.Close();
        }
        private void BotaoAbrirRelatorio_Home_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaRelatorio();
            this.Close();
        }

        private void BotaoAbrirMenu_Home_Click(object sender, RoutedEventArgs e)
        {

        }

     
    }
}