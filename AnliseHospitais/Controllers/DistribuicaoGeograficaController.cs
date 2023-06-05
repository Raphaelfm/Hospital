using AnliseHospitais.Data;
using AnliseHospitais.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnliseHospitais.Controllers
{
    public class DistribuicaoGeograficaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistribuicaoGeograficaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CentroOeste()
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();
            string regiao = "CENTRO-OESTE";

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

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
                data.Add(item.Quantidade);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtenha a lista de estados e municípios do banco de dados
            List<string> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passe os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Nordeste()
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();
            string regiao = "NORDESTE";

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

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
                data.Add(item.Quantidade);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtenha a lista de estados e municípios do banco de dados
            List<string> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passe os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Norte()
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();
            string regiao = "NORTE";

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

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
                data.Add(item.Quantidade);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtenha a lista de estados e municípios do banco de dados
            List<string> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passe os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Sudeste()
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();
            string regiao = "SUDESTE";

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

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
                data.Add(item.Quantidade);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtenha a lista de estados e municípios do banco de dados
            List<string> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passe os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;

            // Retorne os dados para a view
            return View();
        }

        public IActionResult Sul()
        {
            IQueryable<HospitalModel> query = _context.Hospitais.AsQueryable();
            string regiao = "SUL";

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

            List<string> labels = new List<string>();
            List<int> data = new List<int>();

            foreach (var item in contagemHospitais)
            {
                labels.Add($"{item.Regiao} - {item.Uf} - {item.Municipio}");
                data.Add(item.Quantidade);
            }

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            // Obtenha a lista de estados e municípios do banco de dados
            List<string> estados = _context.Hospitais.Select(x => x.Uf).Distinct().ToList();
            List<string> municipios = _context.Hospitais.Select(x => x.Municipio).Distinct().ToList();

            // Passe os valores para a ViewBag
            ViewBag.Estados = estados;
            ViewBag.Municipios = municipios;

            // Retorne os dados para a view
            return View();
        }
    }
}
