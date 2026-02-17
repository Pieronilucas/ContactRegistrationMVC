using System.ComponentModel.DataAnnotations;

namespace ContactRegistration.Models;

public class ContatoModel
{
    public int Id{get;set;}
    
    [Required(ErrorMessage = "Digite o nome do contato.")]
    public string Nome{get;set;}
    
    [Required(ErrorMessage = "Digite o e-mail do contato.")]
    [EmailAddress(ErrorMessage = "E-mail inválido. Por favor, preencha novamente.")]
    public string Email{get;set;}
    
    [Required(ErrorMessage = "Digite o celular do contato.")]
    [Phone(ErrorMessage = "Número inválido. Por favor, preencha novamente.")]
    public string Celular{get;set;}
}
