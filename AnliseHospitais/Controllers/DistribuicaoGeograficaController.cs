using AnliseHospitais.Data;
using AnliseHospitais.Interfaces;
using AnliseHospitais.Models;
using AnliseHospitais.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnliseHospitais.Controllers
{
    public class DistribuicaoGeograficaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRegioesRepository _regioesRepository;

        public DistribuicaoGeograficaController(ApplicationDbContext context, IRegioesRepository regioesRepository)
        {
            _context = context;
            _regioesRepository = regioesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CentroOeste()
        {
            string regiao = "CENTRO-OESTE";

            ObterDadosRegiao(regiao);

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Nordeste()
        {
            string regiao = "NORDESTE";

            ObterDadosRegiao(regiao);

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Norte()
        {
            string regiao = "NORTE";

            ObterDadosRegiao(regiao);

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Sudeste()
        {
            string regiao = "SUDESTE";

            ObterDadosRegiao(regiao);

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Sul()
        {
            string regiao = "SUL";

            ObterDadosRegiao(regiao);

            // Retorne os dados para a view
            return View();
        }

        private void ObterDadosRegiao(string regiao)
        {
            List<(string, int)> contagemHospitais = _regioesRepository.GetHospitaisPorRegiao(regiao);

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add(item.Item1);
                data.Add(item.Item2);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtenha a lista de estados e municípios do banco de dados
            List<string?> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string?> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passe os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;
        }

    }
}
