using GraphQLWebAPI.Infrastructure;
using GraphQLWebAPI.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Queries
{
    public class Query
    {
        [UseDbContext(typeof(DbPrfContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]        
        [GraphQLDescription("Gets the queryable ocorrencias.")]
        public IQueryable<Ocorrencia> GetOcorrencias([ScopedService] DbPrfContext context)
        {
            return context.Ocorrencias;
        }

        [UseDbContext(typeof(DbPrfContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable pessoas.")]
        public IQueryable<Pessoa> GetPessoas([ScopedService] DbPrfContext context)
        {
            return context.Pessoas;
        }
    }
}
