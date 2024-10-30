using Google.Protobuf;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using WPF_API_PIM_IV.Models;

namespace WPF_API_PIM_IV.Controller
{

    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task EnviarDadosAsync(RespostaVisitante resposta)
        {
            try

            {
                // Serializa a classe RespostaVisitante para JSON
                var jsonData = JsonSerializer.Serialize(resposta);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Envia a requisição POST para a API
                var response = await client.PostAsync("http://localhost:5000/api/questionario", content);


                if (response.IsSuccessStatusCode)
                {
                    // Sucesso na requisição
                    MessageBox.Show("Dados enviados com sucesso!");
                }
                else
                {
                    // Falha na requisição
                    MessageBox.Show("Erro ao enviar os dados: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Trata exceções
                Console.WriteLine("Erro: " + ex.Message);
            }
        }


        public static async Task<string> ObterCalculoAsync()
        {
            try
            {
                var response = await client.GetAsync("http://localhost:5000/api/questionario/Calculos");


                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Json retorando:{jsonResponse}");
                    return FormatarCalculoParaString(jsonResponse);

                }

                else
                {
                    return $"Erro ao obter resumo: {response.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }

        }

        private static string FormatarCalculoParaString(string jsonResponse)
        {
            var dados = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, double>>>(jsonResponse);
            var resultadoFormatado = "";

            foreach (var pergunta in dados)
            {
                resultadoFormatado += $"Pergunta: {pergunta.Key}\n";

                foreach (var resposta in pergunta.Value)
                {
                    resultadoFormatado += $"{resposta.Key}: {resposta.Value}%\n";
                }
            }
            return resultadoFormatado;
        }
    }
}
