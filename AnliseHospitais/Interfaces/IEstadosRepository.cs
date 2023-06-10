namespace AnliseHospitais.Interfaces
{
    public interface IEstadosRepository
    {
        List<(string, int)> GetHospitaisPorEstado(string estado);
    }
}
