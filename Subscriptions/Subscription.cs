using GraphQLWebAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Subscriptions
{
    [GraphQLDescription("Represents the subscriptions available")]
    public class Subscription
    {
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added pessoa")]
        public Pessoa OnPessoaAdded([EventMessage] Pessoa pessoa)
        {
            return pessoa;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added ocorrencia")]
        public Ocorrencia OnOcorrenciaAdded([EventMessage] Ocorrencia ocorrencia)
        {
            return ocorrencia;
        }
    }
}
