using ContactRegistration.Models;

namespace ContactRegistration.Helper;

public interface IUserSession
{
    
    void CreateSession(UsuarioModel usuario);
    
    void RemoveSession();
    
    UsuarioModel GetSession();
    
}