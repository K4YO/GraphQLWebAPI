using GraphQLWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace GraphQLWebAPI.Infrastructure
{
    public class DbPrfContext : DbContext
    {
        public DbPrfContext(DbContextOptions<DbPrfContext> options) : base(options)
        {
        }

        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new OcorrenciaConfig());
            modelbuilder.ApplyConfiguration(new PessoaConfig());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            if (!optionsbuilder.IsConfigured)
            {
                optionsbuilder
                    .UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING_DB"), sqlserveroptions => sqlserveroptions.CommandTimeout(120));
            }
        }
    }
}
