using AnliseHospitais.Data;
using AnliseHospitais.Interfaces;
using AnliseHospitais.Models;
using Microsoft.EntityFrameworkCore;

namespace AnliseHospitais.Repositories
{
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<HospitalModel>> ObterLeitosUtiPorCidades(string cidade1, string cidade2, string cidade3)
        {
            var leitosPorCidade = _context.Hospitais
                .Where(x => x.Municipio == cidade1 || x.Municipio == cidade2 || x.Municipio == cidade3)
                .GroupBy(x => x.Municipio)
                .Select(x => new HospitalModel { Municipio = x.Key, UtiTotalExistentes = x.Sum(h => h.UtiTotalExistentes) })
                .ToListAsync();

            return leitosPorCidade;
        }

    }
}
