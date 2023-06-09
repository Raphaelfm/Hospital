﻿using CsvHelper.Configuration.Attributes;

namespace AnliseHospitais.Models
{
    public class HospitalModel
    {
        public int Id { get; set; }
        public int Comp { get; set; }
        public string? Regiao { get; set; }
        public string? Uf { get; set; }
        public string? Municipio { get; set;}
        public string? MotivoDesabilitacao { get; set; }
        public string? CNES { get; set; }
        public string? NomeEstabelecimento { get; set; }
        public string? RazaoSocial { get; set; }
        public string? TpGestao { get; set; }
        public string? CodigoTipoUnidade { get; set;}
        public string? DescricaoTipoUnidade { get; set; }
        public string? NaturezaJuridica { get; set; }
        public string? DescricaoNatureza { get; set; }
        public string? NomeLogradouro { get; set; }
        public string? NumeroEndereco { get; set; }
        public string? NomeComplemento { get; set; }
        public string? NomeBairro { get; set; }
        public string? CodigoCep { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
        public int LeitosExistentes { get; set; }
        public int LeitosSus { get; set; }
        public int UtiTotalExistentes { get; set; }
        public int UtiTotalSus { get; set; }
        public int UtiAdultoExistente { get; set; }
        public int UtiAdultoSus { get; set; }
        public int UtiPediatricoExistentes { get; set; }
        public int UtiPediatricoSus { get; set; }
        public int UtiNeoNatalExistentes { get; set; }
        public int UtiNeoNatalSus { get; set; }
        public int UtiQueimadoExistentes { get; set; }
        public int UtiQueimadoSus { get; set; }
        public int UtiCoronarianaExistentes { get; set; }
        public int UtiCoronarianaSus { get; set; }
    }
}
