using ContactRegistration.Data;
using ContactRegistration.Models;


namespace ContactRegistration.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly BancoContext _context;

    public UsuarioRepository(BancoContext context)
    {
        _context = context;
    }
    
    public UsuarioModel CreateUser(UsuarioModel usuario)
    {
        usuario.CriadoEm = DateTime.Now;
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        
        return usuario;
    }

    public List<UsuarioModel> ListAll()
    {
        return _context.Usuarios.ToList();
    }

    public UsuarioModel? FindUserById(int id)
    {
        return _context.Usuarios.FirstOrDefault(c => c.Id == id);
    }

    public UsuarioModel UpdateUser(UsuarioModel usuario)
    {
        UsuarioModel usuarioUpdate = FindUserById(usuario.Id);

        if (usuarioUpdate == null)
        {
            throw new SystemException("Houve um erro na atualização. Usuário não encontrado");
        }
        usuarioUpdate.Nome = usuario.Nome;
        usuarioUpdate.Email = usuario.Email;
        usuarioUpdate.Login = usuario.Login;
        if (!string.IsNullOrEmpty(usuario.Senha))
        {
            usuarioUpdate.Senha = usuario.Senha;
        }
        usuarioUpdate.Perfil = usuario.Perfil;
        usuario.AtualizadoEm = DateTime.Now;
        usuarioUpdate.AtualizadoEm = usuario.AtualizadoEm;
        
        _context.Usuarios.Update(usuarioUpdate);
        _context.SaveChanges();
        return usuarioUpdate;
    }

    public bool? DeleteUser(int id)
    {   
        var userDelete = FindUserById(id);

        if (userDelete == null)
        {
            throw new SystemException("Usuário inválido.");
        }
        
        _context.Usuarios.Remove(userDelete);
        _context.SaveChanges();
        
        return true;
    }
}