using GraphQLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Ocorrencias
{
    public class OcorrenciaPayload
    {
        public OcorrenciaPayload(Ocorrencia ocorrencia)
        {
            Ocorrencia = ocorrencia;
        }

        public Ocorrencia Ocorrencia { get; set; }
    }
}
