using AnliseHospitais.Data;
using AnliseHospitais.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace AnliseHospitais.Controllers
{
    public class TrataDadosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        ApplicationDbContext _context;
        
        public  TrataDadosController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportarHospitais(IFormFile arquivoCsv)
        {
            if(arquivoCsv != null && arquivoCsv.Length > 0)
            {
                //var caminhoArquivo = Path.Combine(_webHostEnvironment.ContentRootPath, "App_Data", Path.GetFileName(arquivoCsv.FileName));
                var caminhoArquivo = @"D:\Downloads\Leitos_2023.csv";
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await arquivoCsv.CopyToAsync(stream);
                }

                var csvReader = new Utilitarios();
                var hospitais = csvReader.LerCsv(caminhoArquivo);

                // Código  para salvar hospitais no banco de dados
                if (ModelState.IsValid)
                {
                    foreach (var hospital in hospitais)
                    {
                        _context.Add(hospital);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensagem = "Nenhum arquivo foi selecionado.";
            return View();
        }
    }
}
