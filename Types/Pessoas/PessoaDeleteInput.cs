using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Pessoas
{
    public class PessoaDeleteInput
    {
        public PessoaDeleteInput(int id, int numeroPessoa)
        {
            Id = id;
            NumeroPessoa = numeroPessoa;
        }

        public int Id { get; set; }
        public int NumeroPessoa { get; set; }
    }
}
