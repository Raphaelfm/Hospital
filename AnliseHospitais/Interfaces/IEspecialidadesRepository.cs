using AnliseHospitais.Models;

namespace AnliseHospitais.Interfaces
{
    public interface IEspecialidadesRepository
    {
        Task<List<HospitalModel>> ObterLeitosUtiPorCidades(string cidade1, string cidade2, string cidade3);
    }
}
