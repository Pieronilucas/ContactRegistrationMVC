using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel model)
    {
        try
        {
            if (ModelState.IsValid) 
            {
                var login = _usuarioRepository.ObtainLogin(model.Login);
                if (login != null)
                {
                    if (login.SenhaValida(model.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                    
                }
                TempData["ErrorMessage"] = "Usuário e/ou senha inválido(s). Tente novamente!";
            }

            
            return View("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível realizar seu login, Tente novamente! "+ e.Message;
            return RedirectToAction("Index");
        }
    }
}