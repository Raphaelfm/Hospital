namespace AnliseHospitais.Models
{
    public class SelecionarEstadoMunicipioViewModel
    {
        public List<string> Estados { get; set; }
        public List<string> Municipios { get; set; }
        public string EstadoSelecionado { get; set; }
        public string MunicipioSelecionado { get; set; }
    }
}
