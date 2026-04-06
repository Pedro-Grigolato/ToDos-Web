using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoPlatform.Services;
using ToDoPlatform.ViewModels;

namespace ToDoPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(
            ILogger<AccountController> logger,
            IUserService userService
        )
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            // Redireciona usuário já logado
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            var model = new LoginVM
            {
                ReturnUrl = returnUrl ?? Url.Content("~/")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(login);

                if (result.Succeeded)
                    return LocalRedirect(login.ReturnUrl);

                if (result.IsLockedOut)
                    return RedirectToAction("Lockout");

                if (result.IsNotAllowed)
                    return RedirectToAction("AccessDenied");

                // Mensagem de erro padrão
                ModelState.TryAddModelError("", "Usuário e/ou senha inválidos!");
            }

            // Retorna a view com erros
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Chama o serviço para efetuar logout
            await _userService.Logout();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}