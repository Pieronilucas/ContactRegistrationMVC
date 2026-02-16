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
        var contatos  =_repository.Listar();
        return View(contatos);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Edit(int id)
    {
        var contato = _repository.ListarPorId(id);
        return View(contato);
    }
    public IActionResult DeleteConfirmation()
    {
        return View();
    }

    // POST
    [HttpPost]
    public IActionResult Create(ContatoModel contato)
    {
        _repository.Adicionar(contato);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Edit(ContatoModel contato)
    {
        _repository.Atualizar(contato);
        return RedirectToAction("Index");
    }
    
}