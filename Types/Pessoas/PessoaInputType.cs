using GraphQLWebAPI.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Pessoas
{
    public class PessoaInputType : InputObjectType<PessoaInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PessoaInput> descriptor)
        {
            //Name = "pessoaInput";

            descriptor.Description("Representa a entidade do tipo Pessoa");

            descriptor
                .Field(p => p.NumeroPessoa)
                .Description("Representa o numero da Pessoa");
            descriptor
                .Field(p => p.Idade)
                .Description("Representa a idade da Pessoa");
            descriptor
                .Field(p => p.EstadoFisico)
                .Description("Representa a estado físico da Pessoa");
            descriptor
                .Field(p => p.IdOcorrencia)
                .Description("Representa a ocorrência em que a Pessoa foi registrada");
            descriptor
                .Field(p => p.IdVeiculo)
                .Description("Representa o identificador único do veículo em que a Pessoa estava no momento do acidente");
            descriptor
                .Field(p => p.TipoVeiculo)
                .Description("Representa o tipo de veículo da Pessoa");
            descriptor
                .Field(p => p.Marca)
                .Description("Representa a marca do veículo da Pessoa");
            descriptor
                .Field(p => p.AnoFrabricacaoVeiculo)
                .Description("Representa o ano de frabricação do veículo da Pessoa");
            descriptor
                .Field(p => p.TipoEnvolvido)
                .Description("Representa o papel da pessoa envolvida no acidente");
            descriptor
                .Field(p => p.Sexo)
                .Description("Representa o sexo da Pessoa");
            descriptor
                .Field(p => p.Ileso)
                .Description("Representa se a pessoa está ilesa do acidente, ou seja, sem ferimentos");
            descriptor
                .Field(p => p.FeridoLeve)
                .Description("Representa se a pessoa está ferida levimente do acidente");
            descriptor
                .Field(p => p.FeridoGrave)
                .Description("Representa se a pessoa está ferida gravimente do acidente");
            descriptor
                .Field(p => p.Morto)
                .Description("Representa se a pessoa foi morta no acidente");

            base.Configure(descriptor);
        }
    }
}
