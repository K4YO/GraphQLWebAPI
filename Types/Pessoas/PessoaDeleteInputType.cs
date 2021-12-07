using GraphQLWebAPI.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Pessoas
{
    public class PessoaDeleteInputType : InputObjectType<PessoaDeleteInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PessoaDeleteInput> descriptor)
        {
            //Name = "pessoaDelete";

            descriptor.Description("Representa a entidade do tipo Pessoa");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the Pessoa.");

            base.Configure(descriptor);
        }
    }

}
