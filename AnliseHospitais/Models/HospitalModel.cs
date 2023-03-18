using CsvHelper.Configuration.Attributes;

namespace AnliseHospitais.Models
{
    public class HospitalModel
    {
        public int Id { get; set; }

        [Index(0)]
        public int Comp { get; set; }

        [Index(1)]
        public string? Regiao { get; set; }

        [Index(2)] 
        public string? Uf { get; set; }

        [Index(3)]
        public string? Muicipio { get; set;}

        [Index(4)]
        public string? MotivoDesabilitacao { get; set; }

        [Index(5)]
        public string? CNES { get; set; }

        [Index(6)]
        public string? NomeEstabelecimento { get; set; }

        [Index(7)]
        public string? RazaoSocial { get; set; }

        [Index(8)]
        public string? TpGestao { get; set; }

        [Index(9)]
        public string? CodigoTipoUnidade { get; set;}

        [Index(10)]
        public string? DescricaoTipoUnidade { get; set; }

        [Index(11)]
        public string? NaturezaJuridica { get; set; }

        [Index(12)]
        public string? DescricaoNatureza { get; set; }

        [Index(13)]
        public string? NomeLogradouro { get; set; }

        [Index(14)]
        public string? NumeroEndereco { get; set; }

        [Index(15)]
        public string? NomeComplemento { get; set; }

        [Index(16)]
        public string? NomeBairro { get; set; }

        [Index(17)]
        public string? CodigoCep { get; set; }

        [Index(18)]
        public string? NumeroTelefone { get; set; }

        [Index(19)]
        public string? Email { get; set; }

        [Index(20)]
        public int LeitosExistentes { get; set; }

        [Index(21)]
        public int LeitosSus { get; set; }

        [Index(22)]
        public int UtiTotalExistentes { get; set; }

        [Index(23)]
        public int UtiTotalSus { get; set; }

        [Index(24)]
        public int UtiAdultoExistente { get; set; }

        [Index(25)]
        public int UtiAdultoSus { get; set; }

        [Index(26)]
        public int UtiPediatricoExistentes { get; set; }

        [Index(27)]
        public int UtiPediatricoSus { get; set; }

        [Index(28)]
        public int UtiNeoNatalExistentes { get; set; }

        [Index(29)]
        public int UtiNeoNatalSus { get; set; }

        [Index(30)]
        public int UtiQueimadoExistentes { get; set; }

        [Index(31)]
        public int UtiQueimadoSus { get; set; }

        [Index(32)]
        public int UtiCoronarianaExistentes { get; set; }

        [Index(33)]
        public int UtiCoronarianaSus { get; set; }
    }
}
