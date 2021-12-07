using AutoMapper;
using GraphQLWebAPI.Types.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<PessoaInput, Pessoa>();
            CreateMap<Pessoa, PessoaPayload>()
                .ConstructUsing(x=> new PessoaPayload(x));
        }
    }
}
