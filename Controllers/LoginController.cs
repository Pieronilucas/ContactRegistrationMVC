using ContactRegistration.Helper;
using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUserSession _userSession;
    
    public LoginController(IUsuarioRepository usuarioRepository, IUserSession userSession)
    {
        _usuarioRepository = usuarioRepository;
        _userSession = userSession;
    }
    public IActionResult Index()
    {
        if (_userSession.GetSession() != null)
        {
            return RedirectToAction("Index", "Home");
        }
        
        return View();
    }

    public IActionResult RedefinirSenha()
    {
        return View();
    }

    public IActionResult LeavingSession()
    {
        _userSession.RemoveSession();
        
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel model)
    {
        try
        {
            if (ModelState.IsValid) 
            {
                var login = _usuarioRepository.ObtainLogin(model.Login);
                if (login != null && login.SenhaValida(model.Senha))
                {
                        _userSession.CreateSession(login);
                        return RedirectToAction("Index", "Home");
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

    [HttpPost]
    public IActionResult EnviarLinkRedefinir(RedefinirSenhaModel model)
    {
        try
        {
            if (ModelState.IsValid) 
            {
                var login = _usuarioRepository.SearchByEmailAndLogin(model.Email, model.Login);
                if (login != null)
                {
                    string novaSenha = login.GerarNovaSenha();
                    
                    TempData["SuccessMessage"] = "Enviamos para o seu e-mail uma nova senha.";
                    return RedirectToAction("Index", "Login");
                }
                TempData["ErrorMessage"] = "Não foi possível redefinir a senha. Verifique os dados e tente novamente.";
            }

            
            return View("RedefinirSenha");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível redefinir sua senha. Tente novamente! "+ e.Message;
            return RedirectToAction("RedefinirSenha");
        }
    }
}