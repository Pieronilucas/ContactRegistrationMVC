using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepository _repository;
    public ContatoController(IContatoRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index()
    {
        var contatos  =_repository.ListAll();
        return View(contatos);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Edit(int id)
    {
        var contato = _repository.GetById(id);
        return View(contato);
    }
    public IActionResult DeleteConfirmation(int id)
    {
        var contato = _repository.GetById(id);
        return View(contato);
    }

    public IActionResult Delete(int id)
    {
        _repository.DeleteContact(id);
        return RedirectToAction("Index");
    }

    // POST
    [HttpPost]
    public IActionResult Create(ContatoModel contato)
    {
        _repository.AddContact(contato);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Edit(ContatoModel contato)
    {
        _repository.Update(contato);
        return RedirectToAction("Index");
    }
    
}