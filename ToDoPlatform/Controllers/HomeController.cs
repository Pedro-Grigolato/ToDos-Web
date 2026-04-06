using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoPlatform.Models;

namespace ToDoPlatform.Controllers;

[Authorize] // Somente usuários logados podem acessar
public class HomeController : Controller
{
    // Página principal - somente para usuários autenticados
    public IActionResult Index()
    {
        return View();
    }

    // Página pública (opcional)
    [AllowAnonymous] 
    public IActionResult Privacy()
    {
        return View();
    }

    // Página de erro
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        });
    }
}