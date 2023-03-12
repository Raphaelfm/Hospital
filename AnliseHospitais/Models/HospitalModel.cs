namespace AnliseHospitais.Models
{
    public class HospitalModel
    {
        public int Comp { get; set; }
        public string? Regiao { get; set; }
        public string? Uf { get; set; }
        public string? Muicipio { get; set;}
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
        public string? LeitosExistentes { get; set; }
        public string? LeitosSus { get; set; }
        public string? UtiTotalExistentes { get; set; }
        public string? UtiTotalSus { get; set; }
        public string? UtiAdultoExistente { get; set; }
        public string? UtiAdultoSus { get; set; }
        public string? UtiPediatricoExistentes { get; set; }
        public string? UtiPediatricoSus { get; set; }
        public string? UtiNeoNatalExistentes { get; set; }
        public string? UtiNeoNatalSus { get; set; }
        public string? UtiQueimadoExistentes { get; set; }
        public string? UtiQueimadoSus { get; set; }
        public string? UtiCoronarianaExistentes { get; set; }
        public string? UtiCoronarianaSus { get; set; }
    }
}
