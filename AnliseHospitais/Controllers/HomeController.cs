using AnliseHospitais.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnliseHospitais.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AnliseHospitais.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var hospitaisPorEstado = await _context.Hospitais
                .GroupBy(x => x.Uf)
                .Select(x => new HospitaisPorEstado { Estado = x.Key, QuantidadeDeHospitais = x.Count() })
                .ToListAsync();

            return View(hospitaisPorEstado);
        }

        public async Task<IActionResult> Leitos()
        {
            var leitosPorTipoHospitais = await _context.Hospitais
                .GroupBy(x => x.DescricaoNatureza)
                .Select(x => new HospitalModel { DescricaoNatureza = x.Key, LeitosExistentes = x.Sum(h => h.LeitosExistentes) })
                .ToListAsync();

            return View(leitosPorTipoHospitais);
        }

        public IActionResult SelecionarEstadoMunicipio()
        {
            var viewModel = new SelecionarEstadoMunicipioViewModel();

            // Obtem a lista de estados e municípios do banco de dados
            viewModel.Estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            viewModel.Municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            return View(viewModel);
        }


        public IActionResult CompararInformacoes(string estado, string municipio)
        {
            // Obtem as informações para o estado selecionado
            var leitosEstado = _context.Hospitais
                .Where(x => x.Uf == estado)
                .Sum(x => x.LeitosExistentes);

            var hospitaisPublicosEstado = _context.Hospitais
                .Where(x => x.Uf == estado && x.DescricaoNatureza == "HOSPITAL_PUBLICO")
                .Count();

            // Obtem as informações para o município selecionado
            var leitosMunicipio = _context.Hospitais
                .Where(x => x.Uf == estado && x.Municipio == municipio)
                .Sum(x => x.LeitosExistentes);

            var hospitaisPublicosMunicipio = _context.Hospitais
                .Where(x => x.Uf == estado && x.Municipio == municipio && x.DescricaoNatureza == "HOSPITAL_PUBLICO")
                .Count();

            // Cria os dados para exibir nos gráficos
            List<string> labels = new List<string> { "Leitos", "Hospitais Públicos" };
            List<int> dadosEstado = new List<int> { leitosEstado, hospitaisPublicosEstado };
            List<int> dadosMunicipio = new List<int> { leitosMunicipio, hospitaisPublicosMunicipio };

            ViewBag.Labels = labels;
            ViewBag.DadosEstado = dadosEstado;
            ViewBag.DadosMunicipio = dadosMunicipio;

            // Retorne os dados para a view
            return PartialView("_CompararInformacoes");
        }



        //public IActionResult DistribuicaoGeograficaHospitais()
        //{
        //    // Realize a análise para contar a quantidade de hospitais por região, estado e município
        //    var contagemHospitais = _context.Hospitais
        //        .GroupBy(x => new { x.Regiao, x.Uf, x.Municipio })
        //        .Select(x => new
        //        {
        //            Regiao = x.Key.Regiao,
        //            Uf = x.Key.Uf,
        //            Municipio = x.Key.Municipio,
        //            Quantidade = x.Count()
        //        })
        //        .ToList();

        //    // Crie os dados para o gráfico
        //    List<string> labels = new List<string>();
        //    List<int> data = new List<int>();

        //    foreach (var item in contagemHospitais)
        //    {
        //        labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
        //        data.Add(item.Quantidade);
        //    }

        //    // Passe os dados do gráfico para a view
        //    ViewBag.Labels = labels;
        //    ViewBag.Data = data;

        //    return View();
        //}


        //public IActionResult DistribuicaoGeograficaHospitais()
        //{
        //    // Realize a análise para contar a quantidade de hospitais por região, estado e município
        //    var contagemHospitais = _context.Hospitais
        //        .GroupBy(x => new { x.Regiao, x.Uf, x.Municipio })
        //        .Select(x => new
        //        {
        //            Regiao = x.Key.Regiao,
        //            Uf = x.Key.Uf,
        //            Municipio = x.Key.Municipio,
        //            Quantidade = x.Count()
        //        })
        //        .ToList();

        //    // Crie os dados para o gráfico
        //    List<string> labels = new List<string>();
        //    List<int> data = new List<int>();

        //    foreach (var item in contagemHospitais)
        //    {
        //        labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
        //        data.Add(item.Quantidade);
        //    }

        //    // Crie um objeto com os dados do gráfico
        //    var chartData = new
        //    {
        //        Labels = labels,
        //        Data = data
        //    };

        //    return Json(chartData);
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}