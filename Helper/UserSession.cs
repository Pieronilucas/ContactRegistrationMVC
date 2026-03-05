using ContactRegistration.Models;

namespace ContactRegistration.Helper;

public class UserSession : IUserSession
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserSession(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public void CreateSession(UsuarioModel usuario)
    {
        string value = System.Text.Json.JsonSerializer.Serialize(usuario);
        _httpContextAccessor.HttpContext.Session.SetString("LoggedUser", value);
    }

    public UsuarioModel GetSession()
    {
        string UserSession = _httpContextAccessor.HttpContext.Session.GetString("LoggedUser");

        if (string.IsNullOrEmpty(UserSession)) return null;
        
        return System.Text.Json.JsonSerializer.Deserialize<UsuarioModel>(UserSession);
    }

    public void RemoveSession()
    {
        _httpContextAccessor.HttpContext.Session.Remove("LoggedUser");
    }
}