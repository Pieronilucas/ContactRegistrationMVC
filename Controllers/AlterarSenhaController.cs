using ContactRegistration.Helper;
using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class AlterarSenhaController : Controller 
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUserSession _userSession;

    public AlterarSenhaController(IUsuarioRepository usuarioRepository, IUserSession userSession)
    {
        _usuarioRepository = usuarioRepository;
        _userSession = userSession;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Alterar(AlterarSenhaModel model)
    {
        try
        {
            var loggedUser = _userSession.GetSession();
            model.Id = loggedUser.Id;
            
            if (ModelState.IsValid)
            {
                _usuarioRepository.UpdatePassword(model);
                TempData["SuccessMessage"] = "Senha alterada com sucesso!";
                return RedirectToAction("Index",  "AlterarSenha");
            }
            
            return View("Index");
            
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = $"Não foi possível alterar sua senha. Por favor, tente novamente! \n{e.Message}";
            return View("Index");
        }
    }
}