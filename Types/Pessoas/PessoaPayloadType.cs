using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Pessoas
{
    public class PessoaPayloadType: ObjectType<PessoaPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<PessoaPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added pessoa.");

            descriptor
                .Field(p => p.Pessoa)
                .Description("Represents the added pessoa.");

            base.Configure(descriptor);
        }
    }
}
