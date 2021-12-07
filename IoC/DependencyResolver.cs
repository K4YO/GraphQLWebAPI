using GraphQLWebAPI.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Server.Ui.Voyager;
using GraphQLWebAPI.Queries;
using HotChocolate.AspNetCore;
using HotChocolate;
using GraphQLWebAPI.Types.Pessoas;
using GraphQLWebAPI.Types.Ocorrencias;
using GraphQLWebAPI.Types.Returns;
using GraphQLWebAPI.Mutations;
using GraphQLWebAPI.Models;
using System.Reflection;
using GraphQLWebAPI.Subscriptions;

namespace GraphQLWebAPI.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            //services.AddDbContext<DbPrfContext>();
            services.AddDbContextFactory<DbPrfContext>();

            services.AddAutoMapper(new Assembly[] {Assembly.Load("GraphQLWebAPI")});

            //Queries
            //Mutations
            //Types
            //Subscriptions
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<PessoaType>()
                .AddType<PessoaInputType>()
                .AddType<PessoaPayloadType>()
                .AddType<PessoaDeleteInputType>()
                .AddType<OcorrenciaType>()
                .AddType<OcorrenciaDeleteInputType>()
                .AddType<OcorrenciaPayloadType>()
                .AddType<OcorrenciaInputType>()
                .AddType<ReturnType>()           
                //.AddType<ReturnType>()
                //.AddType<ReturnType>()
                //.AddType<ReturnType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();         
        }
    }
}
