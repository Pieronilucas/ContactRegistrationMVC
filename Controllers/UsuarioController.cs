using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _repository;
    
    public UsuarioController(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
        List<UsuarioModel> usuarios = _repository.ListAll();
        
        return View(usuarios);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repository.CreateUser(usuario);
                TempData["SucessMessage"] = "Usuário adicionado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível cadastrar o usuário." + e.Message;
            return RedirectToAction("Index");
        }
    }
}