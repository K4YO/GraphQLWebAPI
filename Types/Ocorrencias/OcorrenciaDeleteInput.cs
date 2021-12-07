using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Ocorrencias
{
    public class OcorrenciaDeleteInput
    {
        public OcorrenciaDeleteInput(int id, int numeroOcorrencia)
        {
            Id = id;
            NumeroOcorrencia = numeroOcorrencia;
        }

        public int Id { get; set; }
        public int NumeroOcorrencia { get; set; }
    }
}
