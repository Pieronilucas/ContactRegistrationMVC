using System.Diagnostics;
using ContactRegistration.Helper;
using Microsoft.AspNetCore.Mvc;
using ContactRegistration.Models;

namespace ContactRegistration.Controllers;

public class HomeController : Controller
{
    private  readonly IUserSession _userSession;
    
    public HomeController(IUserSession userSession)
    {
        _userSession = userSession;
    }
    public IActionResult Index()
    {
        if (_userSession.GetSession() == null)
        {
            return RedirectToAction("Index", "login");
        }
        return View();
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