using GraphQLWebAPI.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Ocorrencias
{
    public class OcorrenciaDeleteInputType : InputObjectType<OcorrenciaDeleteInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<OcorrenciaDeleteInput> descriptor)
        {
            Name = "ocorrenciaDelete";

            descriptor.Description("Representa a entidade do tipo ocorrência");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the ocorrência.");

            base.Configure(descriptor);
        }
    }
}
