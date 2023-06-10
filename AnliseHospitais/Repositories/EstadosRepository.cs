using AnliseHospitais.Data;
using AnliseHospitais.Interfaces;
using AnliseHospitais.Models;

namespace AnliseHospitais.Repositories
{
    public class EstadosRepository : IEstadosRepository
    {
        private readonly ApplicationDbContext _context;

        public EstadosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<(string, int)> GetHospitaisPorEstado(string estado)
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
                .Where(r => r.Uf == estado)
                .ToList();

            List<(string, int)> resultados = contagemHospitais
                .Select(item => ($"{item.Regiao} - {item.Uf} - {item.Municipio}", item.Quantidade))
                .ToList();

            return resultados;
        }
    }
}
