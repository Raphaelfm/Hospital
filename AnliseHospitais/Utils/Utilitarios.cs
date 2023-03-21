using AnliseHospitais.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using System.Globalization;

namespace AnliseHospitais.Utils
{
    public class Utilitarios
    {
        public List<HospitalModel> LerCsv(string caminhoArquivo)
        {
            using (var reader = new StreamReader(caminhoArquivo))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," }))
            {
                var records = csv.GetRecords<HospitaisCsvModel>().ToList();

                var hospitalModel = records.Select((record, index) => new HospitalModel
                {
                    Comp = record.Comp,
                    Regiao = record.Regiao,
                    Uf = record.Uf,
                    Municipio = record.Municipio,
                    MotivoDesabilitacao = record.MotivoDesabilitacao,
                    CNES = record.CNES,
                    NomeEstabelecimento = record.CNES,
                    RazaoSocial = record.RazaoSocial,
                    TpGestao = record.TpGestao,
                    CodigoTipoUnidade = record.CodigoTipoUnidade,
                    DescricaoTipoUnidade = record.DescricaoTipoUnidade,
                    NaturezaJuridica = record.NaturezaJuridica,
                    DescricaoNatureza = record.DescricaoNatureza,
                    NomeLogradouro = record.NomeLogradouro,
                    NumeroEndereco = record.NumeroEndereco,
                    NomeComplemento = record.NomeComplemento,
                    NomeBairro = record.NomeBairro,
                    CodigoCep = record.CodigoCep,
                    NumeroTelefone = record.NumeroTelefone,
                    Email = record.Email,
                    LeitosExistentes = record.LeitosExistentes,
                    LeitosSus = record.LeitosSus,
                    UtiTotalExistentes = record.UtiTotalExistentes,
                    UtiTotalSus = record.UtiTotalSus,
                    UtiAdultoExistente = record.UtiAdultoExistente,
                    UtiAdultoSus = record.UtiAdultoSus,
                    UtiPediatricoExistentes = record.UtiPediatricoExistentes,
                    UtiPediatricoSus = record.UtiPediatricoSus,
                    UtiNeoNatalExistentes = record.UtiNeoNatalExistentes,
                    UtiNeoNatalSus = record.UtiNeoNatalSus,
                    UtiQueimadoExistentes = record.UtiQueimadoExistentes,
                    UtiQueimadoSus = record.UtiQueimadoSus,
                    UtiCoronarianaExistentes = record.UtiCoronarianaExistentes,
                    UtiCoronarianaSus = record.UtiCoronarianaSus
                }).ToList();

                return hospitalModel;
            }
        }

    }
}
