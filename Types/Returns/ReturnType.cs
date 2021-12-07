using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Returns
{
    public class ReturnType
    {
        public bool Status { get; set; }
        public string Description { get; set; }
        public string Operation { get; protected set; }
    }

    public class EditedPayload : ReturnType
    {
        public EditedPayload()
        {
            Operation = "Edit";
        }
    }

    public class DeletedPayload : ReturnType
    {
        public DeletedPayload()
        {
            Operation = "Delete";
        }
    }

    public class EditedPayloadType : ObjectType<EditedPayload>
    {
           protected override void Configure(IObjectTypeDescriptor<EditedPayload> descriptor)
           {
            descriptor.Field(x => x.Status).Name("status");
            descriptor.Field(x => x.Description).Name("description");
            descriptor.Field(x => x.Operation).Name("operation");
           }
          
    }

    public class DeletedPayloadType : ObjectType<DeletedPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeletedPayload> descriptor)
        {
            descriptor.Field(x => x.Status).Name("status");
            descriptor.Field(x => x.Description).Name("description");
            descriptor.Field(x => x.Operation).Name("operation");
 
        }
    }

}
