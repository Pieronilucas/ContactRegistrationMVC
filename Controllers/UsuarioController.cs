using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class UsuarioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}