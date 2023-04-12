using AnliseHospitais.Data;
using AnliseHospitais.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnliseHospitais.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeFullName(string userId, string newFullName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.UserCompleteName = newFullName;
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Manage");
            }
            // redirecionar para a página de erro ou exibir uma mensagem de erro
            return RedirectToAction("Error", "Home");
        }
    }
}
