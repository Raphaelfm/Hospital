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
                var records = csv.GetRecords<HospitalModel>().ToList();
                return records;
            }
        }

    }
}
