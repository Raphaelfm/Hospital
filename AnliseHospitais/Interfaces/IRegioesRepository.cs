namespace AnliseHospitais.Interfaces
{
    public interface IRegioesRepository
    {
        List<(string, int)> GetHospitaisPorRegiao(string regiao);
        List<(string, int)> GetHospitaisPorRegiao();
    }
}
