using System.ComponentModel.DataAnnotations;
using ContactRegistration.Enums;

namespace ContactRegistration.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite o nome do usuário.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Digite o e-mail do usuário.")]
    [EmailAddress(ErrorMessage = "E-mail inválido. Por favor, preencha novamente.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Digite o login do usuário.")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Digite a senha do usuário.")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "Selecione o perfil do usuário.")]
    public PerfilEnum  Perfil { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }


    public bool SenhaValida(string senha)
    {
        return  BCrypt.Net.BCrypt.Verify(senha, Senha);
    }
}