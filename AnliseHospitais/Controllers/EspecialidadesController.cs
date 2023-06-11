using AnliseHospitais.Data;
using AnliseHospitais.Interfaces;
using AnliseHospitais.Models;
using AnliseHospitais.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnliseHospitais.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly IEspecialidadesRepository _repository;
        private readonly ApplicationDbContext _context;

        public EspecialidadesController(IEspecialidadesRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelecionarCidade()
        {
            var hospitais = _context.Hospitais.Select(x => new HospitalModel { Municipio = x.Municipio }).Distinct().ToList();

            return View(hospitais);
        }


        public async Task<IActionResult> LeitosUtitotal(string cidade1, string cidade2, string cidade3)
        {
            var utisPorCidade = await _repository.ObterLeitosUtiPorCidades(cidade1, cidade2, cidade3);

            return View(utisPorCidade);
        }

        //public async Task<IActionResult> LeitosUtitotal(string cidade1, string cidade2, string cidade3)
        //{
        //    var leitosPorCidade = await _context.Hospitais
        //        .Where(x => x.Municipio == "CARIACICA" || x.Municipio == "VITORIA" || x.Municipio == "VILA VELHA")
        //        .GroupBy(x => x.Municipio)
        //        .Select(x => new { Municipio = x.Key, LeitosUti = x.Sum(h => h.UtiTotalExistentes) })
        //        .ToListAsync();

        //    return View(leitosPorCidade);
        //}


    }
}
