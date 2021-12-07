using GraphQLWebAPI.Infrastructure;
using GraphQLWebAPI.Models;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Resolvers
{
    public class Resolver
    {
        public IQueryable<Pessoa> GetPessoas(Ocorrencia ocorrencia, [ScopedService] DbPrfContext context)
        {
            return context.Pessoas.Where(p => p.IdOcorrencia == ocorrencia.Id);
        }

        public IQueryable<Ocorrencia> GetOcorrencias(Pessoa pessoa, [ScopedService] DbPrfContext context)
        {
            return context.Ocorrencias.Where(p => p.Id == pessoa.IdOcorrencia);
        }

        public Ocorrencia GetOcorrencia(Pessoa pessoa, [ScopedService] DbPrfContext context)
        {
            return context.Ocorrencias.FirstOrDefault(p => p.Id == pessoa.IdOcorrencia);
        }
    }
}
