using ContactRegistration.Models;

namespace ContactRegistration.Repository;

public interface IUsuarioRepository
{
    List<UsuarioModel> ListAll();
    UsuarioModel? FindUserById(int id);
    UsuarioModel CreateUser(UsuarioModel usuario);
    UsuarioModel UpdateUser(UsuarioModel usuario);
    bool? DeleteUser(int id);
}