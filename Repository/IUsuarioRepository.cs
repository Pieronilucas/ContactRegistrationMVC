using ContactRegistration.Models;

namespace ContactRegistration.Repository;

public interface IUsuarioRepository
{
    UsuarioModel? ObtainLogin(string login);
    UsuarioModel? SearchByEmailAndLogin(string email, string login);
    List<UsuarioModel> ListAll();
    UsuarioModel? FindUserById(int id);
    UsuarioModel CreateUser(UsuarioModel usuario);
    UsuarioModel UpdateUser(UsuarioModel usuario);
    bool? DeleteUser(int id);
    UsuarioModel? UpdatePassword(AlterarSenhaModel AlterarSenha);
}