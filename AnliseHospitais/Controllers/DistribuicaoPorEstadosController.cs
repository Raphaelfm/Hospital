using AnliseHospitais.Data;
using AnliseHospitais.Interfaces;
using AnliseHospitais.Models;
using AnliseHospitais.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnliseHospitais.Controllers
{
    public class DistribuicaoPorEstadosController : Controller
    {
        private readonly IEstadosRepository _estadosRepository;
        private readonly ApplicationDbContext _context;

        public DistribuicaoPorEstadosController(IEstadosRepository estadosRepository, ApplicationDbContext contex)
        {
            _estadosRepository = estadosRepository;
            _context = contex;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelecionarEstado()
        {
            var viewModel = new SelecionarEstadoMunicipioViewModel();

            // Obtem a lista de estados do banco de dados
            viewModel.Estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();

            return View(viewModel);
        }

        public IActionResult CarregaInformacoes(string estado)
        {
            ObterDadosEstado(estado);

            // Retorne os dados para a view
            return PartialView("_ComparacaoEstados");
        }

        private void ObterDadosEstado(string estado)
        {
            List<(string, int)> contagemHospitais = _estadosRepository.GetHospitaisPorEstado(estado);

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add(item.Item1);
                data.Add(item.Item2);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtem a lista de estados e municípios do banco de dados
            List<string?> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string?> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passa os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;
        }
    }
}
