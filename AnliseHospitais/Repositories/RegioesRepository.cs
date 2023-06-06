using AnliseHospitais.Data;
using AnliseHospitais.Interfaces;
using AnliseHospitais.Models;

namespace AnliseHospitais.Repositories
{
    public class RegioesRepository : IRegioesRepository
    {
        private readonly ApplicationDbContext _context;

        public RegioesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<(string, int)> GetHospitaisPorRegiao(string regiao)
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();

            var contagemHospitais = query
                .GroupBy(x => new { x.Regiao, x.Uf, x.Municipio })
                .Select(x => new
                {
                    Regiao = x.Key.Regiao,
                    Uf = x.Key.Uf,
                    Municipio = x.Key.Municipio,
                    Quantidade = x.Count()
                })
                .Where(r => r.Regiao == regiao)
                .ToList();

            List<(string, int)> resultados = contagemHospitais
                .Select(item => ($"{item.Regiao} - {item.Uf} - {item.Municipio}", item.Quantidade))
                .ToList();

            return resultados;
        }

        public List<(string, int)> GetHospitaisPorRegiao()
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();

            var contagemHospitais = query
                .GroupBy(x => new { x.Regiao, x.Uf, x.Municipio })
                .Select(x => new
                {
                    Regiao = x.Key.Regiao,
                    Uf = x.Key.Uf,
                    Municipio = x.Key.Municipio,
                    Quantidade = x.Count()
                })
                .ToList();

            List<(string, int)> resultados = contagemHospitais
                .Select(item => ($"{item.Regiao} - {item.Uf} - {item.Municipio}", item.Quantidade))
                .ToList();

            return resultados;
        }

    }
}
