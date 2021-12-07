using AutoMapper;
using GraphQLWebAPI.Infrastructure;
using GraphQLWebAPI.Models;
using GraphQLWebAPI.Subscriptions;
using GraphQLWebAPI.Types.Pessoas;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading;
using System.Threading.Tasks;
using GraphQLWebAPI.Types.Returns;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GraphQLWebAPI.Types.Ocorrencias;

namespace GraphQLWebAPI.Mutations
{
    [GraphQLDescription("Representa as mutations disponíveis")]
    public class Mutation
    {
        private readonly IMapper _mapper;

        public Mutation(IMapper mapper)
        {
            _mapper = mapper;
        }

        [UseDbContext(typeof(DbPrfContext))]
        [GraphQLDescription("Adiciona uma Pessoa")]
        public async Task<PessoaPayload> CreatePessoa(PessoaInput input, [ScopedService] DbPrfContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var pessoa = _mapper.Map<Pessoa>(input);

            context.Pessoas.Add(pessoa);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPessoaAdded), pessoa, cancellationToken);

            return new PessoaPayload(pessoa);
        }


        [UseDbContext(typeof(DbPrfContext))]
        [GraphQLDescription("Atualiza a Pessoa")]
        public async Task<EditedPayload> UpdatePessoa(int id,PessoaInput input, [ScopedService] DbPrfContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var pessoa = _mapper.Map<Pessoa>(input);

            var entity = await context.Pessoas.FindAsync(id);
            if (entity == null)
            {
                return new EditedPayload() { Status = false, Description = "NotContent" };
            }
            
            var updatedPessoa = (Pessoa)CheckUpdateObject(entity, pessoa);
            context.Entry(entity).CurrentValues.SetValues(updatedPessoa);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPessoaAdded), pessoa, cancellationToken);

            return new EditedPayload() { Status = true, Description = "Updated" };
        }

        [UseDbContext(typeof(DbPrfContext))]
        [GraphQLDescription("Remove a Pessoa")]
        public async Task<DeletedPayload> DeletePessoa(PessoaDeleteInput input, [ScopedService] DbPrfContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {

            var entity = await context.Pessoas.FindAsync(input.Id);
            if (entity == null)
            {
                return new DeletedPayload() { Status = false, Description = "NotContent" };
            }

            context.Pessoas.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return new DeletedPayload() { Status = true, Description = "Deleted" };
        }

        [UseDbContext(typeof(DbPrfContext))]
        [GraphQLDescription("Adiciona uma Ocorrência")]
        public async Task<OcorrenciaPayload> CreateOcorrencia(OcorrenciaInput input, [ScopedService] DbPrfContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var ocorrencia = _mapper.Map<Ocorrencia>(input);

            context.Ocorrencias.Add(ocorrencia);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnOcorrenciaAdded), ocorrencia, cancellationToken);

            return new OcorrenciaPayload(ocorrencia);
        }

        [UseDbContext(typeof(DbPrfContext))]
        [GraphQLDescription("Atualiza a Ocorrência")]
        public async Task<EditedPayload> UpdateOcorrencia(int id, OcorrenciaInput input, [ScopedService] DbPrfContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var ocorrencia = _mapper.Map<Ocorrencia>(input);

            var entity = await context.Ocorrencias.FindAsync(id);
            if (entity == null)
            {
                return new EditedPayload() { Status = false, Description = "NotContent" };
            }

            var updatedPessoa = (Pessoa)CheckUpdateObject(entity, ocorrencia);
            context.Entry(entity).CurrentValues.SetValues(updatedPessoa);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnOcorrenciaAdded), ocorrencia, cancellationToken);

            return new EditedPayload() { Status = true, Description = "Updated" };
        }

        [UseDbContext(typeof(DbPrfContext))]
        [GraphQLDescription("Remove a Ocorrência")]
        public async Task<DeletedPayload> DeleteOcorrencia(OcorrenciaDeleteInput input, [ScopedService] DbPrfContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {

            var entity = await context.Ocorrencias.FindAsync(input.Id);
            if (entity == null)
            {
                return new DeletedPayload() { Status = false, Description = "NotContent" };
            }

            context.Ocorrencias.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return new DeletedPayload() { Status = true, Description = "Deleted" };
        }

        private static object CheckUpdateObject(object originalObj, object updateObj)
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                if (property.GetValue(updateObj, null) == null)
                {
                    property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
                    .GetValue(originalObj, null));
                }
            }
            return updateObj;
        }
    }
}
