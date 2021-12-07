using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Types.Pessoas
{
    public class PessoaInput
    {
        public PessoaInput(int numeroPessoa, int idOcorrencia, int? idVeiculo, string tipoVeiculo, string marca, int? anoFrabricacaoVeiculo, string tipoEnvolvido, string estadoFisico, int? idade, string sexo, bool? ileso, bool? feridoLeve, bool? feridoGrave, bool? morto)
        {
            NumeroPessoa = numeroPessoa;
            IdOcorrencia = idOcorrencia;
            IdVeiculo = idVeiculo;
            TipoVeiculo = tipoVeiculo;
            Marca = marca;
            AnoFrabricacaoVeiculo = anoFrabricacaoVeiculo;
            TipoEnvolvido = tipoEnvolvido;
            EstadoFisico = estadoFisico;
            Idade = idade;
            Sexo = sexo;
            Ileso = ileso;
            FeridoLeve = feridoLeve;
            FeridoGrave = feridoGrave;
            Morto = morto;
        }

        public int NumeroPessoa { get; set; }
        public int IdOcorrencia { get; set; }
        public int? IdVeiculo { get; set; }
        public string TipoVeiculo { get; set; }
        public string Marca { get; set; }
        public int? AnoFrabricacaoVeiculo { get; set; }
        public string TipoEnvolvido { get; set; }
        public string EstadoFisico { get; set; }
        public int? Idade { get; set; }
        public string Sexo { get; set; }
        public Boolean? Ileso { get; set; }
        public Boolean? FeridoLeve { get; set; }
        public Boolean? FeridoGrave { get; set; }
        public Boolean? Morto { get; set; }
    }
}
