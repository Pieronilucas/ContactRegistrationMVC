using System.Text.RegularExpressions;
using ContactRegistration.Filter;
using ContactRegistration.Models;
using ContactRegistration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistration.Controllers;

[LoggedUserPages]
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
        var contatos = _repository.ListAll();
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
        try
        {
            _repository.DeleteContact(id);
            TempData["SucessMessage"] = "Contato excluído com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível excluir o contato." + e.Message;
            return RedirectToAction("Index");
        }
    }

    // POST
    [HttpPost]
    public IActionResult Create(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                contato.Celular = Regex.Replace(contato.Celular ?? "", @"\D", "");
                _repository.AddContact(contato);
                TempData["SucessMessage"] = "Contato adicionado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(contato);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível cadastrar o contato." + e.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Edit(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                contato.Celular = Regex.Replace(contato.Celular ?? "", @"\D", "");
                _repository.Update(contato);
                TempData["SucessMessage"] = "Contato atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(contato);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Não foi possível cadastrar o contato." + e.Message;
            return RedirectToAction("Index");
        }
    }
}