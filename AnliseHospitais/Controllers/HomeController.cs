using AnliseHospitais.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnliseHospitais.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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