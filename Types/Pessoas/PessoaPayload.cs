using GraphQLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Pessoas
{
    public class PessoaPayload
    {
        public PessoaPayload(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public Pessoa Pessoa { get; set; }
    }
}
