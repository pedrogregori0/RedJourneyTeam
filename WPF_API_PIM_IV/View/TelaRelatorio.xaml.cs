using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using WPF_API_PIM_IV.Controller;

namespace WPF_API_PIM_IV
{
    public partial class TelaRelatorio : Window
    {
        Controle controle = new Controle();

        public TelaRelatorio()
        {
            InitializeComponent();
            CarregarDadosRelatorio(); 
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

        public async void CarregarDadosRelatorio()
        {
            var dados = await ObterDadosRelatorio();

            //verificar o porque não esta sendo convetido o Json para o Objeto que vai pro LiveCharts

            // Configurar o gráfico para Pergunta 1

/* teste de grafico
  
            DonutPergunta1.Series = new SeriesCollection
{
    new PieSeries { Title = "Muito", Values = new ChartValues<double> { 30 } },
    new PieSeries { Title = "Moderadamente", Values = new ChartValues<double> { 20 } },
    new PieSeries { Title = "Pouco", Values = new ChartValues<double> { 10 } },
    new PieSeries { Title = "Nada", Values = new ChartValues<double> { 40 } }
};

*/
            
            DonutPergunta1.Series = new SeriesCollection
                {
                    new PieSeries { Title = "Muito Claras", Values = new ChartValues<double> { dados.Pergunta1.GetValueOrDefault("Muito Claras", 0) } },
                    new PieSeries { Title = "Claras", Values = new ChartValues<double> { dados.Pergunta1.GetValueOrDefault("Claras",0) } },
                    new PieSeries { Title = "Pouco Claras", Values = new ChartValues<double> { dados.Pergunta1.GetValueOrDefault("Pouco Claras",0) } },
                    new PieSeries { Title = "Confusas", Values = new ChartValues<double> { dados.Pergunta1.GetValueOrDefault("Confusas",0) } }

                };
            
            
            DonutPergunta2.Series = new SeriesCollection
                {
                    new PieSeries { Title = "Muito", Values = new ChartValues<double> { dados.Pergunta2.GetValueOrDefault("Muito", 0) } },
                    new PieSeries { Title = "Moderadamente", Values = new ChartValues<double> { dados.Pergunta2.GetValueOrDefault("Moderadamente",0) } },
                    new PieSeries { Title = "Pouco", Values = new ChartValues<double> { dados.Pergunta2.GetValueOrDefault("Pouco",0) } },
                    new PieSeries { Title = "Nada", Values = new ChartValues<double> { dados.Pergunta2.GetValueOrDefault("Nada",0) } }

                };

            DonutPergunta3.Series = new SeriesCollection
                {
                    new PieSeries { Title = "Muito Alta", Values = new ChartValues<double> { dados.Pergunta3.GetValueOrDefault("Muito Alta", 0) } },
                    new PieSeries { Title = "Alta", Values = new ChartValues<double> { dados.Pergunta3.GetValueOrDefault("Alta",0) } },
                    new PieSeries { Title = "Moderada", Values = new ChartValues<double> { dados.Pergunta3.GetValueOrDefault("Moderada",0) } },
                    new PieSeries { Title = "Baixa", Values = new ChartValues<double> { dados.Pergunta3.GetValueOrDefault("Baixa",0) } }

                };
        }
        private async Task<DadosRelatorio> ObterDadosRelatorio()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("http://localhost:5000/api/questionario/Calculos");

                response = response.Replace("*", "").Replace("Clalys", "Claras");

                return JsonSerializer.Deserialize<DadosRelatorio>(response);
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string resultado = await ApiService.ObterCalculoAsync();
            MessageBox.Show(resultado, "resumo das perguntas");
        }
    }

    public class DadosRelatorio
    {
        [JsonPropertyName("RespostaPergunta1")]
        public Dictionary<string, double> Pergunta1 { get; set; }

        [JsonPropertyName("RespostaPergunta2")]
        public Dictionary<string, double> Pergunta2 { get; set; }

        [JsonPropertyName("RespostaPergunta3")]
        public Dictionary<string, double> Pergunta3 { get; set; }
    }

}
