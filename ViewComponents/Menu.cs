using ContactRegistration.Helper;
using ContactRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.ViewComponents;

public class Menu : ViewComponent
{
    private readonly IUserSession _userSession;


    public Menu(IUserSession userSession)
    {
        _userSession = userSession;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string userSession = HttpContext.Session.GetString("LoggedUser");

        if (string.IsNullOrEmpty(userSession)) return Content("");

        UsuarioModel user = System.Text.Json.JsonSerializer.Deserialize<UsuarioModel>(userSession);

        if (user == null) return Content("");

        return View(user);
    }
}