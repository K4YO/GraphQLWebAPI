using HotChocolate.Types;
using GraphQLWebAPI.Models;
using GraphQLWebAPI.Resolvers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLWebAPI.Infrastructure;

namespace GraphQLWebAPI.Types.Ocorrencias

{
    public class OcorrenciaType: ObjectType<Ocorrencia>
    {
        protected override void Configure(IObjectTypeDescriptor<Ocorrencia> descriptor)
        {
            //Name = "ocorrencia";

            descriptor.Description("Representa a entidade do tipo ocorrência");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the ocorrência.");

            descriptor
                .Field(p => p.NumeroOcorrencia)
                .Description("Representa o numero da ocorrência");     
            descriptor
                .Field(p => p.DataHora)
                .Description("Representa a data em que ocorreu o acidente"); 
            descriptor
                .Field(p => p.Horario)
                .Description("Representa o horário em que ocorreu o acidente");   
            descriptor
                .Field(p => p.Uf)
                .Description("Representa o estado em que ocorreu o acidente");
            descriptor
                .Field(p => p.Br)
                .Description("Representa a rodovia em que ocorreu o acidente");
            descriptor
                .Field(p => p.Km)
                .Description("Representa a Km da rodovia em que ocorreu o acidente");   
            descriptor
                .Field(p => p.Municipio)
                .Description("Representa o município em que ocorreu o acidente");   
            descriptor
                .Field(p => p.CausaAcidente)
                .Description("Representa a causa do acidente");   
            descriptor
                .Field(p => p.TipoAcidente)
                .Description("Representa a tipo do acidente");   
            descriptor
                .Field(p => p.ClassificacaoAcidente)
                .Description("Representa a classificação do acidente");   
            descriptor
                .Field(p => p.FaseDia)
                .Description("Representa a fase do dia no momento do acidente");   
            descriptor
                .Field(p => p.SentidoVia)
                .Description("Representa a Sentido Via no momento do acidente");   
            descriptor
                .Field(p => p.CondicaoMetereologica)
                .Description("Representa a condicão metereológica no momento do acidente");     
            descriptor
                .Field(p => p.TipoPista)
                .Description("Representa o tipo de pista da rodovia");
            descriptor
                .Field(p => p.TracadoVia)
                .Description("Representa o traçado da via na rodovia");
            descriptor
                .Field(p => p.UsoSolo)
                .Description("Representa o uso solo na rodovia");
            descriptor
                .Field(p => p.TotalPessoas)
                .Description("Representa o total de pessoas envolvidas na ocorrência");
            descriptor
                .Field(p => p.TotalMortos)
                .Description("Representa o total de pessoas mortas no acidente");
            descriptor
                .Field(p => p.TotalFeridosLeves)
                .Description("Representa  o total de pessoas feridas leves no acidente");
            descriptor
                .Field(p => p.TotalFeridosGrave)
                .Description("Representa  o total de pessoas feridos graves no acidente");
            descriptor
                .Field(p => p.TotalIlesos)
                .Description("Representa  o total de pessoas ilesos no acidente");
            descriptor
                .Field(p => p.TotalIgnorados)
                .Description("Representa  o total de pessoas ignorados no acidente");
            descriptor
                .Field(p => p.TotalFeridos)
                .Description("Representa  o total de pessoas feridos (leves e graves) no acidente");
            descriptor
                .Field(p => p.TotalVeiculos)
                .Description("Representa  o total de veículos envolvidos no acidente");
            descriptor
                .Field(p => p.Latitude)
                .Description("Representa a Latitude da localização do acidente");
            descriptor
                .Field(p => p.Longitude)
                .Description("Representa Longitude da localização do acidente");
            descriptor
                .Field(p => p.Regional)
                .Description("Representa a regional da delegacia da ocorrência");
            descriptor
                .Field(p => p.Delegacia)
                .Description("Representa a delegacia da ocorrência");
            descriptor
                .Field(p => p.Uop)
                .Description("Representa a unidade operacional que atendeu a ocorrência");  
            

            descriptor
                .Field(p => p.Pessoas)
                .ResolveWith<Resolver>(p => p.GetPessoas(default!, default!))
                .UseDbContext<DbPrfContext>()
                .Description("Lista de Pessoas relacionadas a essa ocorrência");
        }
    }
}
