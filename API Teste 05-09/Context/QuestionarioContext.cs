using API_Teste_05_09.modelo;
using API_Web;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_Teste_05_09.Context
{
    public class QuestionarioContext : DbContext
    {


        public QuestionarioContext(DbContextOptions<QuestionarioContext> options) : base(options) { }

        public DbSet<Questionario> Questionario { get; set; }

    }




}
