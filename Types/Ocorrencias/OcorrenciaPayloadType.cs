using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Ocorrencias
{
    public class OcorrenciaPayloadType : ObjectType<OcorrenciaPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<OcorrenciaPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added ocorrencia.");

            descriptor
                .Field(p => p.Ocorrencia)
                .Description("Represents the added ocorrencia.");

            base.Configure(descriptor);
        }
    }
}
