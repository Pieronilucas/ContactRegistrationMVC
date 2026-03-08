using ContactRegistration.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

[LoggedUserPages]
public class RestritoController : Controller
{
    
    public IActionResult Index() 
    {
        return View();
    }
    
}