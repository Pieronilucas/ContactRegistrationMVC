using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactRegistration.Models;

namespace ContactRegistration.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        HomeModel homeModel = new HomeModel();

        homeModel.Name = "Lucas Pieroni";
        homeModel.Email = "Lucaspieroni819@gmail.com";
        
        return View(homeModel);
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