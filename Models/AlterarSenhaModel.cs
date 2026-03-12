using System.ComponentModel.DataAnnotations;
using ContactRegistration.Filter;

namespace ContactRegistration.Models;

[LoggedUserPages]
public class AlterarSenhaModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Informe a senha atual.")]
    public string SenhaAtual { get; set; }
    [Required(ErrorMessage = "Informe a nova senha.")]
    public string NovaSenha { get; set; }
    [Required(ErrorMessage = "Confirme a nova senha.")]
    [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha.")]
    public string ConfirmacaoSenha { get; set; }
}