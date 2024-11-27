using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        
        public TextBox textboxSelecionado;
        public TelaQuestionario()
        {
            InitializeComponent();
        }


        private async void BotaoFinalizarQuestionario_Click(object sender, RoutedEventArgs e)
        {

            respostaAtual.Nome = TxbNome.Text;
            respostaAtual.Email = TxbEmail.Text;
            respostaAtual.RespostaPergunta1 = controle.ObterRespostaSelecionadaP1(StackPanelOpcoesPergunta1);
            respostaAtual.RespostaPergunta2 = controle.ObterRespostaSelecioandaP2(StackPanelOpcoesPergunta2);
            respostaAtual.RespostaPergunta3 = controle.ObterRespostaSelecioandaP3(StackPanelOpcoesPergunta3);
            respostaAtual.SugestaoDeTema = TxbSugestaoTema.Text;



            if (string.IsNullOrEmpty(respostaAtual.Nome) ||
                string.IsNullOrEmpty(respostaAtual.RespostaPergunta1) ||
                string.IsNullOrEmpty(respostaAtual.RespostaPergunta2) ||
                string.IsNullOrEmpty(respostaAtual.RespostaPergunta3))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            // Tenta enviar os dados para a API
            try
            {
                await ApiService.EnviarDadosAsync(respostaAtual);
                //MessageBox.Show("Questionário enviado com sucesso!");

                // Redireciona para a tela inicial e fecha a tela atual
                controle.AbrirTelaRelatorio();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar o questionário: " + ex.Message);
            }


            //controle.AbrirTelaInicial();
            //this.Close();
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

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textboxSelecionado = sender as TextBox;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            controle.AbrirTeclado(this);
        }
    }
}
