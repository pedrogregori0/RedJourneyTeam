using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using WPF_API_PIM_IV.Models;

    namespace WPF_API_PIM_IV
    {
        internal class Conexao
        {
            public static void TestarConexao()
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MessageBox.Show("Conexão com o banco de dados foi bem-sucedida!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                    }
                }
            }

        public static void InserirNoBanco(RespostaVisitante visitante)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Visitantes (Nome, Email, RespostaPergunta1, RespostaPergunta2, RespostaPergunta3, SugestaoTema) " +
                                   "VALUES (@Nome, @Email, @Resposta1, @Resposta2, @Resposta3, @Sugestao)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros
                        command.Parameters.AddWithValue("@Nome", visitante.Nome);
                        command.Parameters.AddWithValue("@Email", visitante.Email);
                        command.Parameters.AddWithValue("@Resposta1", visitante.RespostaPergunta1);
                        command.Parameters.AddWithValue("@Resposta2", visitante.RespostaPergunta2);
                        command.Parameters.AddWithValue("@Resposta3", visitante.RespostaPergunta3);
                        command.Parameters.AddWithValue("@Sugestao", visitante.SugestaoDeTema);

                        // Executa a query
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dados inseridos com sucesso no banco de dados!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir no banco de dados: " + ex.Message);
                }
            }
        }

    }
    }
