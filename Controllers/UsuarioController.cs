using ContactRegistration.Filter;
using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

[AdmindUserPages]
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
    
    public IActionResult Edit(int id)
    {
        var usuario = _repository.FindUserById(id);
        return View(usuario);
    }
    
    public IActionResult DeleteConfirmation(int id)
    {
        var usuario = _repository.FindUserById(id);
        return View(usuario);
    }
    
    public IActionResult Delete(int id)
    {
        try
        {
            _repository.DeleteUser(id);
            TempData["SucessMessage"] = "Usuário excluído com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível excluir o usuário. " + e.Message;
            return RedirectToAction("Index");
        }
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
            TempData["ErrorMessage"] = "Não foi possível cadastrar o usuário. " + e.Message;
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost]
    public IActionResult Edit(UsuarioModel usuario)
    {
        try
        {
            ModelState.Remove("Senha");
            if (ModelState.IsValid)
            {
                
                _repository.UpdateUser(usuario);
                TempData["SucessMessage"] = "Usuário atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível editar o usuário." + e.Message;
            return RedirectToAction("Index");
        }
    }
}