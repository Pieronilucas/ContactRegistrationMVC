using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class ContatoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Edit()
    {
        return View();
    }
    public IActionResult DeleteConfirmation()
    {
        return View();
    }
    
    
}