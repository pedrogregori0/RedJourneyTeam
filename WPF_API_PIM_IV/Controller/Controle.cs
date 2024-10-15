using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WPF_API_PIM_IV.view;
using System.Data.SqlClient;
using System.Configuration;
namespace WPF_API_PIM_IV.Controller
{
    class Controle
    {
        public void AbrirTelaInicial()
        {
            MainWindow telaInicial = new MainWindow();
            telaInicial.Show();
        }

        public void AbrirTeclado() 
        { 
            TelaTeclado telaTeclado = new TelaTeclado();
            telaTeclado.Show();
        }
        public void AbrirTelaQuestionario()
        {
            TelaQuestionario telaQuestionario = new TelaQuestionario();
            telaQuestionario.Show();
        }
        public void AbrirTelaRelatorio()
        {
            TelaRelatorio telaRelatorio = new TelaRelatorio();
            telaRelatorio.Show();
        }
        public void AbrirTelaObra1() 
        { 
            TelaObra1 telaObra1 = new TelaObra1();
            telaObra1.Show();
            
        }
        public void AbrirTelaObra2()
        {
            TelaObra2 telaObra2 = new TelaObra2();
            telaObra2.Show();
        }
        public void AbrirTelaObra3()
        {
            TelaObra3 telaObra3 = new TelaObra3();
            telaObra3.Show();
        }
        public void AbrirTelaObra4()
        {
            TelaObra4 telaObra4 = new TelaObra4();
            telaObra4.Show();
        }
        public void AbrirTelaObra5()
        {
            TelaObra5 telaObra5 = new TelaObra5();
            telaObra5.Show();
        }
        public void AbrirTelaObra6()
        {
            TelaObra6 telaObra6 = new TelaObra6(); 
            telaObra6.Show();
        }

        public void Navegar(int indiceAtual, bool proximo)
        {
            int NovoIndice = proximo ? indiceAtual + 1 : indiceAtual - 1;
            
            switch(NovoIndice)
            {
                case 1:
                    TelaObra1 telaObra1 = new TelaObra1();
                    telaObra1.Show();
                    break;  
                case 2:
                    TelaObra2 telaObra2 = new TelaObra2();
                    telaObra2.Show();
                    break;
                case 3:
                    TelaObra3 telaObra3 = new TelaObra3();
                    telaObra3.Show();
                    break;
                case 4:
                    TelaObra4 telaObra4 = new TelaObra4();
                    telaObra4.Show();
                    break;
                case 5:
                    TelaObra5 telaObra5 = new TelaObra5();
                    telaObra5.Show();
                    break;
                case 6:
                    TelaObra6 telaObra6 =  new TelaObra6();
                    telaObra6.Show();
                    break;

                default:
                    MessageBox.Show("Nenhuma obra foi encontrada");
                    break;



            }
        }

        public string ObterRespostaSelecionadaP1(StackPanel stackPanelPergunta1)
        {
            foreach(var resposta in stackPanelPergunta1.Children)
            {
                if (resposta is RadioButton radiobutton && radiobutton.IsChecked == true)
                {
                    return radiobutton.Content.ToString();
                }
            }

            return string.Empty;
        }

        public string ObterRespostaSelecioandaP2(StackPanel stackPanelPergunta2)
        {
            foreach (var resposta in stackPanelPergunta2.Children)
            {
                if (resposta is RadioButton radiobutton && radiobutton.IsChecked == true)
                {
                    return radiobutton.Content.ToString();
                }
            }

            return string.Empty;
        }

        public string ObterRespostaSelecioandaP3(StackPanel stackPanelPergunta3)
        {   
            foreach (var resposta in stackPanelPergunta3.Children)
            {
                if (resposta is RadioButton radiobutton && radiobutton.IsChecked == true)
                {
                    return radiobutton.Content.ToString();
                }
            }
            return string.Empty;

        }

        

    }
}
