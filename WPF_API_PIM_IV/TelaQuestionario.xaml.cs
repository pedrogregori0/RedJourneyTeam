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
using WPF_API_PIM_IV.Models;

namespace WPF_API_PIM_IV
{
    /// <summary>
    /// Lógica interna para TelaQuestionario.xaml
    /// </summary>
    public partial class TelaQuestionario : Window
    {   
        Controle controle = new Controle();
        RespostaVisitante respostaAtual = new RespostaVisitante();

        public TelaQuestionario()
        {
            InitializeComponent();
        }

        
        private void BotaoFinalizarQuestionario_Click(object sender, RoutedEventArgs e)
        {

            respostaAtual.RespostaPergunta1 = controle.ObterRespostaSelecionadaP1(StackPanelOpcoesPergunta1);
            respostaAtual.RespostaPergunta2 = controle.ObterRespostaSelecioandaP2(StackPanelOpcoesPergunta2);
            respostaAtual.RespostaPergunta3 = controle.ObterRespostaSelecioandaP3(StackPanelOpcoesPergunta3);
            respostaAtual.Nome = TxbNome.Text;
            respostaAtual.Email = TxbEmail.Text;
            respostaAtual.SugestaoDeTema = TxbSugestaoTema.Text;

            Conexao.InserirNoBanco(respostaAtual);
            
            controle.AbrirTelaInicial();
            this.Close();
        }

        private void BotaoAbrirMenu_Questionario_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaInicial();
            this.Close();
        }

        private void BotaoAbrirQuestionario_Questionario_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void BotaoAbrirRelatorio_Questionario_Click(object sender, RoutedEventArgs e)
        {
            controle.AbrirTelaRelatorio();
            this.Close();
        }

     
    }
}
